using Airlines_Booking.Migrations;
using Airlines_Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Airlines_Booking.Controllers
{
    public class AdminController : Controller
    {
        private Mycontext _con;
        private IWebHostEnvironment _evn;
        public AdminController(Mycontext con, IWebHostEnvironment evn)
        {
            _evn = evn;
            _con = con;
        }
        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                TempData["admin_count"] = _con.tbl_admin.Count();
                TempData["user_count"] = _con.tbl_user.Count();
                TempData["plane_count"] = _con.tbl_plan.Count();
                TempData["package_count"] = _con.tbl_packages.Count();
                TempData["country_count"] = _con.tbl_country.Count();
                TempData["city_count"] = _con.tbl_city.Count();
                TempData["flight_count"] = _con.tbl_flightsmanagement.Count();
                TempData["staff_count"] = _con.tbl_staff.Count();
                var sum_package = _con.tbl_packagebooking.Sum(e => e.total);
                var sum_airline = _con.tbl_airlineticket.Sum(e => e.total);
                var seats = _con.tbl_flightsmanagement.Sum(e => e.seat_avaiable);
                TempData["seat"] = seats;
                TempData["earning"] = sum_airline + sum_package;
                TempData["booking_count"] = _con.tbl_airlineticket.Count();
                TempData["contact_count"] = _con.tbl_contact.Count();
                TempData["faq_count"] = _con.tbl_faq.Count();
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        public IActionResult admin_logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("admin_login");
        }
        public IActionResult admin_login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult admin_login(string adminemail, string adminpassword)
        {
            var data = _con.tbl_admin.FirstOrDefault(a => a.admin_email == adminemail);
            if (data != null && data.admin_password == adminpassword)
            {
                if (data.status == 1)
                {
                    HttpContext.Session.SetString("admin_session", data.id.ToString());
                    return RedirectToAction("index", "admin");
                }
                else
                {
                    return RedirectToAction("waitedpage", "admin");
                }

            }
            else
            {
                TempData["errormsg"] = "The email or password is incorrected";
                return View();
            }

        }
        [HttpGet]
        public IActionResult user_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<user> user_record = new List<user>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    user_record = _con.tbl_user.ToList();
                }
                else
                {
                    user_record = _con.tbl_user.FromSqlInterpolated(
                       $"select * from tbl_user where user_name like '%'+ {textsearch}+ '%' or user_email  like '%'+ {textsearch}+ '%'").ToList();
                }
                if (user_record.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }


                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record,
                    admin_record = adminRecord

                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        public IActionResult user_delete(int id)
        {
            var del = _con.tbl_user.Find(id);
            _con.tbl_user.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("user_details");
        }
        public IActionResult user_status(int id)
        {
            var find_id = _con.tbl_user.Find(id);
            if (find_id.status == 1)
            {
                find_id.status = 0;
                find_id.status_update = "Deactivate";
            }
            else
            {
                find_id.status = 1;
                find_id.status_update = "Active";

            }
            _con.SaveChanges();
            return RedirectToAction("user_details");

        }
        public IActionResult admin_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                List<admin> admin_record = new List<admin>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    admin_record = _con.tbl_admin.ToList();
                }
                else
                {
                    admin_record = _con.tbl_admin.FromSqlInterpolated(
                       $"select * from tbl_admin where admin_name  like '%'+ {textsearch}+'%' or admin_email  like '%'+ {textsearch}+ '%'").ToList();
                }
                if (admin_record.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }


                mainmodel data = new mainmodel()
                {

                    admin_record = adminRecord,
                    adminrecord = admin_record

                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        public IActionResult admin_delete(int id)
        {
            var del = _con.tbl_admin.Find(id);
            _con.tbl_admin.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("admin_details");
        }
        [HttpPost]
        public IActionResult add_admin(admin myadmin, string admin_password, string comfirm_password, IFormFile admin_Image)
        {
            var emailexisiting = _con.tbl_admin.FirstOrDefault(u => u.admin_email == myadmin.admin_email);
            if (emailexisiting == null)
            {
                if (admin_password == comfirm_password)
                {
                    string filetext = Path.GetExtension(admin_Image.FileName);
                    if (filetext == ".jpg" || filetext == ".png" || filetext == ".jpeg")
                    {
                        string fileName = Path.GetFileName(admin_Image.FileName);
                        string filePath = Path.Combine(_evn.WebRootPath, "adminimages", fileName);
                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        admin_Image.CopyTo(fs);
                        myadmin.admin_Image = fileName;
                        myadmin.status = 1;
                        myadmin.status_update = "Active";
                        _con.tbl_admin.Add(myadmin);
                        TempData["error"] = "the admin is added successfully";
                    }
                    else
                    {
                        TempData["error"] = "the picture is not supported";
                    }

                }
                else
                {
                    TempData["error"] = "The comfrim password is not match";
                }
            }
            else
            {
                TempData["error"] = "the email is already registered";
            }

            _con.SaveChanges();
            return RedirectToAction("admin_details");
        }
        [HttpPost]
        public IActionResult update_pictures(admin myadmin, IFormFile admin_Image)
        {
            string filetext = Path.GetExtension(admin_Image.FileName);
            if (filetext == ".jpg"||filetext==".png"||filetext==".jpeg")
            {
                string fileName = Path.GetFileName(admin_Image.FileName);
                string filePath = Path.Combine(_evn.WebRootPath, "adminimages", fileName);
                FileStream fs = new FileStream(filePath, FileMode.Create);
                admin_Image.CopyTo(fs);
                myadmin.admin_Image = fileName;
                _con.tbl_admin.Update(myadmin);
                _con.SaveChanges();

            }
            return RedirectToAction("admin_details");

        }


        public IActionResult update_admin(int id)
        {

            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                var admindata = _con.tbl_admin.Find(id);
                mainmodel data = new mainmodel()
                {
                    admin_data = admindata,
                    admin_record = adminRecord,

                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }



        }
        [HttpPost]
        public IActionResult update_admin(admin myadmin)
        {
            _con.tbl_admin.Update(myadmin);
            _con.SaveChanges();
            return RedirectToAction("admin_details");
        }
        public IActionResult status_admin(int id)
        {
            var findid = _con.tbl_admin.Find(id);
            if (findid.status == 1)
            {
                findid.status = 0;
                findid.status_update = "Deactivate";
            }
            else
            {
                findid.status = 1;
                findid.status_update = "Activate";
            }
            _con.SaveChanges();
            return RedirectToAction("admin_details");
        }
        public IActionResult waitedpage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult plan_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<Plan> plan_record = new List<Plan>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    plan_record = _con.tbl_plan.ToList();
                }
                else
                {
                    plan_record = _con.tbl_plan.FromSqlInterpolated(
                       $"select * from tbl_plan where plan_name like '%'+ {textsearch}+'%'").ToList();
                }
                if (plan_record.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }

                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                mainmodel data = new mainmodel()
                {
                    plan_record = plan_record,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        [HttpPost]
        public IActionResult add_plan(Plan myplan)
        {
            Random random = new Random();
            int plan_id = random.Next(00000, 99999);
            var mydata = "NCA-" + plan_id.ToString();
            myplan.plan_id = mydata;

            _con.tbl_plan.Add(myplan);
            _con.SaveChanges();
            TempData["plan_added"] = "The plan is added successfully ";
            return RedirectToAction("plan_details");
        }
        public IActionResult update_plan(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var find_id = _con.tbl_plan.Find(id);
                mainmodel data = new mainmodel()
                {
                    plan_data = find_id,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        [HttpPost]
        public IActionResult update_plan(Plan myplan)
        {

            _con.tbl_plan.Update(myplan);
            _con.SaveChanges();
            return RedirectToAction("plan_details");

        }
        public IActionResult delete_plan(int id)
        {
            var del = _con.tbl_plan.Find(id);
            _con.tbl_plan.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("plan_details");
        }
        [HttpGet]
        public IActionResult country_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                List<Country> country_record = new List<Country>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    country_record = _con.tbl_country.ToList();
                }
                else
                {
                    country_record = _con.tbl_country.FromSqlInterpolated(
                       $"select * from tbl_country where Name  like '%'+ {textsearch}+'%'").ToList();
                }
                if (country_record.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }

                mainmodel data = new mainmodel()
                {
                    countries_record = country_record,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult add_country(Country con)
        {
            var countryExisiting = _con.tbl_country.FirstOrDefault(u => u.Name == con.Name);
            if (countryExisiting == null)
            {
                _con.tbl_country.Add(con);
                _con.SaveChanges();
                TempData["country_added"] = "The country is added successfully";
                return RedirectToAction("country_details");
            }
            else
            {
                TempData["country_added"] = "The country is alredy added";
                return RedirectToAction("country_details");
            }
        }
        public IActionResult update_country(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var country_data = _con.tbl_country.Find(id);
                mainmodel data = new mainmodel()
                {
                    countrydata = country_data,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult update_country(Country conu)
        {
            var countryExisiting = _con.tbl_country.FirstOrDefault(u => u.Name == conu.Name);
            if (countryExisiting == null)
            {
                _con.tbl_country.Update(conu);
                _con.SaveChanges();
                TempData["country_added"] = "The country is updated successfully";
                return RedirectToAction("country_details");
            }
            else
            {
                TempData["country_added"] = "The country is alredy added";
                return RedirectToAction("country_details");
            }
        }
        public IActionResult delete_country(int id)
        {
            var del = _con.tbl_country.Find(id);
            _con.tbl_country.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("country_details");
        }
        public IActionResult staff_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<employee> staffRecord = new List<employee>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    staffRecord = _con.tbl_staff.ToList();
                }
                else
                {
                    staffRecord = _con.tbl_staff.FromSqlInterpolated($"Select * from tbl_staff where Username like '%'+ {textsearch}+'%'").ToList();
                }
                if (staffRecord.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                mainmodel data = new mainmodel()
                {
                    staff_record = staffRecord,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");

            }
        }
        [HttpPost]
        public IActionResult add_staaff(employee emp)
        {
            var usernameexisiting = _con.tbl_staff.FirstOrDefault(u => u.Username == emp.Username);
            if (usernameexisiting == null)
            {
                _con.tbl_staff.Add(emp);
                emp.Status = 1;
                emp.status_update = "Activate";
                _con.SaveChanges();
                TempData["staff_added"] = "The staff is added succesfully";
                return RedirectToAction("staff_details");
            }
            else
            {

                TempData["staff_added"] = "The username is already registered";
                return RedirectToAction("staff_details");

            }


        }
        public IActionResult update_staff(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var findid = _con.tbl_staff.Find(id);
                mainmodel data = new mainmodel()
                {
                    emp_data = findid,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult update_staff(employee myemp)
        {
            _con.tbl_staff.Update(myemp);
            _con.SaveChanges();
            return RedirectToAction("staff_details");
        }
        public IActionResult update_flight(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var findid = _con.tbl_flightsmanagement.Find(id);
                mainmodel data = new mainmodel()
                {
                    flight_data = findid,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult update_flight(flight my_flight)
        {
            my_flight.seat_avaiable = my_flight.busneiss_seats + my_flight.economy_seats;
            _con.tbl_flightsmanagement.Update(my_flight);
            _con.SaveChanges();
            return RedirectToAction("flight_details");
        }
        public IActionResult Status_staff(int id)
        {
            var ids = _con.tbl_staff.Find(id);
            if (ids.Status == 1)
            {
                ids.Status = 0;
                ids.status_update = "Deactivate";
            }
            else
            {
                ids.Status = 1;
                ids.status_update = "Activate";

            }
            _con.SaveChanges();
            return RedirectToAction("staff_details");
        }
        public IActionResult delete_staff(int id)
        {
            var del = _con.tbl_staff.Find(id);
            _con.tbl_staff.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("staff_details");
        }
        [HttpGet]
        public IActionResult flight_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                List<flight> flight_record = new List<flight>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    flight_record = _con.tbl_flightsmanagement.Include(e => e.country).Include(e => e.plane).Include(e => e.city).ToList();
                }
                else
                {
                    flight_record = _con.tbl_flightsmanagement.FromSqlInterpolated($"Select * from tbl_flightsmanagement where Name like '%'+ {textsearch}+'%'").Include
                        (e => e.country).Include(e => e.plane).ToList();
                }
                if (flight_record.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }


                var plane_record = _con.tbl_plan.ToList();
                var country_record = _con.tbl_country.ToList();
                var city_record = _con.tbl_city.ToList();
                mainmodel data = new mainmodel()
                {
                    countries_record = country_record,
                    cityrecord = city_record,
                    plan_record = plane_record,
                    flight_record = flight_record,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult add_flight(flight myflight)
        {
            var name_exting=_con.tbl_flightsmanagement.FirstOrDefault(e=>e.Name== myflight.Name);
            if (name_exting == null)
            {

                var traveled_time = TimeSpan.Parse(myflight.Timing);
                var arrived_time = TimeSpan.Parse(myflight.arrived_time);

                var duartion = traveled_time - arrived_time;
                var hours = (int)duartion.TotalHours;
                var myduartion = hours.ToString();
                if (hours <= 0)
                {
                    var num1 = -hours - hours;
                    var num2 = num1.ToString();
                    myflight.duration = num2;
                }
                else
                {
                    myflight.duration = myduartion;
                }
                myflight.Status = 1;
                myflight.Seats = 0;
                myflight.seat_avaiable = myflight.economy_seats + myflight.busneiss_seats;
                _con.tbl_flightsmanagement.Add(myflight);
                _con.SaveChanges();
                TempData["flight_added"] = "The flight is added successfully";
                return RedirectToAction("flight_details");
            }
            else
            {
                TempData["flight_added"] = "The flight is already added ";
                return RedirectToAction("flight_details");
            }
        }
        public IActionResult delete_flight(int id)
        {
            var del = _con.tbl_flightsmanagement.Find(id);
            _con.tbl_flightsmanagement.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("flight_details");
        }
        public IActionResult status_flight(int id)
        {
            var findid = _con.tbl_flightsmanagement.Find(id);
            if (findid.Status == 0)
            {
                findid.Status = 1;
            }
            else
            {
                findid.Status = 0;
            }
            _con.SaveChanges();
            return RedirectToAction("flight_details");
        }

        public IActionResult flight_data(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var findid = _con.tbl_flightsmanagement.Find(id);
                var plane = _con.tbl_plan.Where(e => e.id == findid.Plane_id).ToList();
                var country = _con.tbl_country.Where(e => e.Id == findid.travel_from).ToList();
                var city = _con.tbl_city.Where(e => e.id == findid.city_id).ToList();
                mainmodel data = new mainmodel()
                { plan_record = plane,
                    cityrecord = city,
                    countries_record = country,
                    flight_data = findid,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }

        public IActionResult cities_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<city> city_record = new List<city>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    city_record = _con.tbl_city.ToList();
                }
                else
                {
                    city_record = _con.tbl_city.FromSqlInterpolated($"Select * from tbl_city where city_name like '%'+ {textsearch}+'%'").ToList();
                }
                if (city_record.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                mainmodel data = new mainmodel()
                {
                    cityrecord = city_record,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");

            }
        }
        public IActionResult add_City(city mycity)
        {
            var nameExisitng = _con.tbl_city.FirstOrDefault(e => e.city_name == mycity.city_name);
            if (nameExisitng == null)
            {
                _con.tbl_city.Add(mycity);
                _con.SaveChanges();
                TempData["flight_added"] = "The city is added successfully";
                return RedirectToAction("cities_details");
            }
            else
            {
                TempData["flight_added"] = "The city is already added";
                return RedirectToAction("cities_details");
            }

        }
        public IActionResult delete_city(int id)
        {
            var del = _con.tbl_city.Find(id);
            _con.tbl_city.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("cities_details");
        }
        public IActionResult update_city(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var city_data = _con.tbl_city.Find(id);
                mainmodel data = new mainmodel()
                {
                    city_data = city_data,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        [HttpPost]
        public IActionResult update_city(city mycity)
        {
            var nameExisitng = _con.tbl_city.FirstOrDefault(e => e.city_name == mycity.city_name);
            if (nameExisitng == null)
            {
                _con.tbl_city.Update(mycity);
                _con.SaveChanges();
                TempData["flight_added"] = "The city is update successfully";
                return RedirectToAction("cities_details");
            }
            else
            {
                TempData["flight_added"] = "The city is already added";
                return RedirectToAction("cities_details");
            }
        }
        public IActionResult bookingTicket(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<ticketBooking> booking_ticket = new List<ticketBooking>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    booking_ticket = _con.tbl_airlineticket.ToList();
                }
                else
                {
                    booking_ticket = _con.tbl_airlineticket.FromSqlInterpolated($"select * from tbl_airlineticket where ticket_id like '%'+ {textsearch}+'%' or name like '%'+ {textsearch}+'%'")
                       .ToList();
                }
                if (booking_ticket.Count == 0)
                {
                    TempData["msg"] = $"not record for{textsearch}";
                }
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                mainmodel data = new mainmodel()
                {
                    booking_record = booking_ticket,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        public IActionResult TicketBooking_delete(int id)
        {
            var del = _con.tbl_airlineticket.Find(id);
            _con.tbl_airlineticket.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("bookingTicket");
        }
        public IActionResult billing_status(int id)
        {
            var findId = _con.tbl_airlineticket.Find(id);
            if (findId.Status == 0)
            {
                findId.Status = 1;
            }
            else
            {
                findId.Status = 0;
            }
            _con.SaveChanges();
            return RedirectToAction("bookingTicket");
        }
        public IActionResult broadpass_status(int id)
        {
            var findId = _con.tbl_airlineticket.Find(id);
            if (findId.broadpass == 0)
            {
                findId.broadpass = 1;
                findId.paid = "paid";
            }

            _con.SaveChanges();
            return RedirectToAction("bookingTicket");
        }
        [HttpGet]
        public IActionResult contact_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<contact> contactdetails = new List<contact>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    contactdetails = _con.tbl_contact.ToList();
                }
                else
                {
                    contactdetails = _con.tbl_contact.FromSqlInterpolated($"Select * from tbl_contact where name like '%' + {textsearch}+ '%' ").ToList();
                }
                if (contactdetails.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                mainmodel data = new mainmodel()
                {
                    contactRecord = contactdetails,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }


        }
        public IActionResult contact_delete(int id)
        {
            var my = _con.tbl_contact.Find(id);
            _con.tbl_contact.Remove(my);
            _con.SaveChanges();
            return RedirectToAction("contact_details");

        }
        public IActionResult booking_details(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var details = _con.tbl_airlineticket.Find(id);
                mainmodel data = new mainmodel()
                {
                    booking_data = details,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpGet]
        public IActionResult packages_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<Packages> packages_detail = new List<Packages>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    packages_detail = _con.tbl_packages.ToList();
                }
                else
                {
                    packages_detail = _con.tbl_packages.FromSqlInterpolated($"Select * from tbl_packages where name like '%' + {textsearch}+ '%' ").ToList();
                }
                if (packages_detail.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();

                mainmodel data = new mainmodel()
                {
                    packages_record = packages_detail,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }



        }
        [HttpPost]
        public IActionResult add_packages(Packages package)
        {
            var name_exsiting = _con.tbl_packages.FirstOrDefault(e => e.Name == package.Name);
            if(name_exsiting == null)
            {
                _con.tbl_packages.Add(package);
                _con.SaveChanges();
                TempData["plan_added"] = "The package is added successfully";
                return RedirectToAction("packages_details");
            }
            else
            {
                TempData["plan_added"] = "The package is already added";
                return RedirectToAction("packages_details");

            }
        
        }

        public IActionResult delete_Package(int id)
        {
            var del = _con.tbl_packages.Find(id);
            _con.tbl_packages.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("packages_details");
        }
        public IActionResult update_package(int id)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var details = _con.tbl_packages.Find(id);
                mainmodel data = new mainmodel()
                {
                    packages_data = details,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }
        }
        [HttpPost]
        public IActionResult update_package(Packages package)
        {
            _con.tbl_packages.Update(package);
            _con.SaveChanges();
            return RedirectToAction("packages_details");
        }
        [HttpGet]
        public IActionResult Packagesbooked_details(string textsearch)
        {

            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<package_booked> packages_detail = new List<package_booked>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    packages_detail = _con.tbl_packagebooking.ToList();
                }
                else
                {
                    packages_detail = _con.tbl_packagebooking.FromSqlInterpolated($"Select * from  tbl_packagebooking where name like '%' + {textsearch}+ '%' or email like '%' + {textsearch}+ '%' or packages_name like '%' + {textsearch}+ '%' ").ToList();
                }
                if (packages_detail.Count == 0)
                {
                    TempData["msg"] = $"Not record for {textsearch}";
                }

                var adminRecord = _con.tbl_admin.Where(e => e.id == int.Parse(login)).ToList();
                var details = _con.tbl_packagebooking.ToList();
                mainmodel data = new mainmodel()
                {
                    packages_booked = packages_detail,
                    admin_record = adminRecord
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("admin_login");
            }

        }
        public IActionResult status_bookedpackage(int id)
        {
            var find_id = _con.tbl_packagebooking.Find(id);
            if (find_id.status == 0)
            {
                find_id.status = 1;
            }
            _con.SaveChanges();
            return RedirectToAction("Packagesbooked_details");
        }

        public IActionResult delete_packaged_booked(int id)
        {
            var find_id = _con.tbl_packagebooking.Find(id);
            _con.tbl_packagebooking.Remove(find_id);
            _con.SaveChanges();
            return RedirectToAction("Packagesbooked_details");

        }
    }
   
}

    