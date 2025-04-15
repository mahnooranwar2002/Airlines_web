using Airlines_Booking.Migrations;
using Airlines_Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airlines_Booking.Controllers
{
    public class StaffController : Controller
    {
        private Mycontext _con;
        public StaffController(Mycontext con)
        {
            _con = con;
        }
        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("staff_session");
            if (login != null)
            {
                TempData["flight_count"] = _con.tbl_flightsmanagement.Count();

                TempData["booking_count"] = _con.tbl_airlineticket.Count();
                TempData["booking_packages"] = _con.tbl_packagebooking.Count();
                var staff_record = _con.tbl_staff.Where(e => e.Id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    emp_record = staff_record
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("staff_login","staff");
            }
        }
        public IActionResult staff_logout()
        {
            HttpContext.Session.Remove("staff_session");
            return RedirectToAction("staff_login", "staff");
        }
        public IActionResult staff_login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult staff_login(string S_name,string S_pass)
        {
            var data = _con.tbl_staff.FirstOrDefault(a => a.Username == S_name);
            if (data != null && data.Password == S_pass)
            {
                if (data.Status == 1)
                {
                    HttpContext.Session.SetString("staff_session", data.Id.ToString());
                    return RedirectToAction("index", "staff");
                }
                else
                {
                    return RedirectToAction("waitedpage", "admin");
                }

            }
            else
            {
                TempData["errormsg"] = "The username or password is incorrected";
                return View();
            }
        }
        public IActionResult update_staff(int id)
        {
            var login = HttpContext.Session.GetString("staff_session");
            if (login != null)
            {
                var staff_record = _con.tbl_staff.Where(e => e.Id == int.Parse(login)).ToList();
                var staff_data = _con.tbl_staff.Find(id);
                mainmodel data = new mainmodel()
                {
                    emp_data=staff_data,
                    emp_record = staff_record

                };
                return View(data);
            }
            else
            {
                return RedirectToAction("staff_login","staff");
            }
        }
        [HttpPost]
        public IActionResult update_staff(employee emps)
        {
            _con.tbl_staff.Update(emps);
            _con.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult flight_details(string textsearch)
        {
            var login = HttpContext.Session.GetString("staff_session");
            if (login != null)
            {
                var staff_record = _con.tbl_staff.Where(e => e.Id == int.Parse(login)).ToList();
                List<flight> flight_record = new List<flight>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    flight_record = _con.tbl_flightsmanagement.Include(e => e.country).Include(e => e.plane).Include(e => e.city).ToList();
                }
                else
                {
                    flight_record = _con.tbl_flightsmanagement.FromSqlInterpolated($"Select * from tbl_flightsmanagement where Name like '%'+ {textsearch} +'%'").Include
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
                 emp_record=staff_record
                };
                return View(data);
            }
            else
            {
                return RedirectToAction("staff_login","staff");
            }
        }
        [HttpPost]
        public IActionResult add_flights(flight myflight)
        {
            _con.tbl_flightsmanagement.Add(myflight);
            _con.SaveChanges();
            TempData["flight_added"] = "The flight is added successfully";
            return RedirectToAction("flight_details");
        }
        public IActionResult delete_flight(int id)
        {
            var del = _con.tbl_flightsmanagement.Find(id);
            _con.tbl_flightsmanagement.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("flight_details");
        }

        public IActionResult flight_status(int id)
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
        public IActionResult booking_detail(string textsearch)
        {
            var login = HttpContext.Session.GetString("staff_session");
            if (login != null)
            {
                List<ticketBooking> booking_ticket = new List<ticketBooking>();
                if (string.IsNullOrEmpty(textsearch))
                {
                    booking_ticket = _con.tbl_airlineticket.ToList();
                }
                else
                {
                    booking_ticket = _con.tbl_airlineticket.FromSqlInterpolated($"select * from tbl_airlineticket where ticket_id like '%'+ {textsearch}+ '%' or name like '%'+ {textsearch}+ '%'")
                        .ToList();
                }
                if (booking_ticket.Count == 0)
                {
                    TempData["msg"] = $"not record for{textsearch}";
                }
            
                var staff_record = _con.tbl_staff.Where(e => e.Id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    booking_record = booking_ticket,
                    emp_record = staff_record


                };
                return View(data);
             
             
            }
            else
            {
                return RedirectToAction("admin_login","admin");
            }

        }
        public IActionResult broadpass_statu(int id)
        {
            var ids = _con.tbl_airlineticket.Find(id);
            if (ids.broadpass == 0)
            {
                ids.broadpass = 1;
            }
            
            _con.SaveChanges();
            return RedirectToAction("booking_detail");
        }
        public IActionResult booked_details(int id)
        {
            var login = HttpContext.Session.GetString("staff_session");
            if (login != null)
            {
              
                var details = _con.tbl_airlineticket.Find(id);
                var staff_record = _con.tbl_staff.Where(e => e.Id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
               booking_data=details,
                    emp_record = staff_record


                };
                return View(data);

               
            }
            else
            {
                return RedirectToAction("admin_login","admin");
            }
        }
        public IActionResult packages_booking(string textsearch)
        {
            var login = HttpContext.Session.GetString("staff_session");
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

                var details = _con.tbl_packagebooking.ToList();
                var staff_record = _con.tbl_staff.Where(e => e.Id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    packages_booked = packages_detail,
                    emp_record = staff_record


                };
                return View(data);


            }
            else
            {
                return RedirectToAction("admin_login", "admin");
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
            return RedirectToAction("packages_booking");

        }
    }
}
