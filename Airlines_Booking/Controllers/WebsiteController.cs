using Airlines_Booking.Migrations;
using Airlines_Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelectPdf;

namespace Airlines_Booking.Controllers
{
    public class WebsiteController : Controller
    {
        private Mycontext _con;
        private IWebHostEnvironment _evn;
        public WebsiteController(Mycontext con, IWebHostEnvironment evn)
        {
            _con = con;
            _evn = evn;
        }

        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }

            return View();
        }
        public IActionResult about()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult productdestination()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult destination_details()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult destination()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult blog()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult blog_detail()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult gallery()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult our_team()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult faq()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult Testimonial()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        public IActionResult not_found()
        {
            return View();
        }
        public IActionResult contact()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                {
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                TempData["error2"] = "my2";

            }
            return View();
        }
        [HttpPost]
        public IActionResult contact(contact cont)
        {
            _con.tbl_contact.Add(cont);
            _con.SaveChanges();
            TempData["error123"] = "thankyou for contact us ,our team answer your query as soon as possible";

            return RedirectToAction("contact");
        }
        [HttpGet]
        public IActionResult flight_details(string mydate, string date)
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                List<flight> myflight = new List<flight>();
                if (string.IsNullOrEmpty(mydate))
                {
                    myflight = _con.tbl_flightsmanagement.FromSqlInterpolated($"select * from tbl_flightsmanagement where status = 1").Include(e => e.city).Include(e => e.country).Include(e => e.plane).ToList();

                }
                else
                {
                    myflight = _con.tbl_flightsmanagement.FromSqlInterpolated($"select * from tbl_flightsmanagement where status = 1 and airline_date={mydate}").Include(e => e.city).Include(e => e.country).Include(e => e.plane).ToList();

                }
                if (myflight.Count == 0)
                {
                    TempData["date"] = $"there is not flight for  {mydate}";
                }
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                mainmodel data = new mainmodel()
                { flight_record = myflight,
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                return RedirectToAction("user_login", "user");

            }
        }
        public IActionResult booked_flight(int id)
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                var find_id = _con.tbl_flightsmanagement.Find(id);
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                var city_data = _con.tbl_city.ToList();

                mainmodel data = new mainmodel()
                {
                    flight_data = find_id,
                    cityrecord = city_data,
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                return RedirectToAction("user_login", "user");

            }
        }
        [HttpPost]
        public IActionResult booked_flight(int id, ticketBooking booking)
        {
            var find_id = _con.tbl_flightsmanagement.Find(id);
            booking.plane_id = find_id.Id;
            var rate = 15;
            var mybbarrahe = 30 * booking.Number_of_passengers;
            Random random = new Random();
            int seat_num = random.Next(00, 99);
            var seat_number = seat_num.ToString();
            int number = random.Next(00000, 999999);
            int number1 = random.Next(000000, 9999999);
            int number2 = random.Next(000, 999);

            var numstring = number.ToString();
            var numstring2 = number1.ToString();
            var numstring3 = number2.ToString();
            booking.ticket_id = numstring + "-" + numstring2 + "-" + numstring3;
            if (booking.barrage >= mybbarrahe || booking.barrage <= mybbarrahe)
            {

                if (booking.category == "economy")
                {
                    if (booking.Number_of_passengers <= find_id.economy_seats)
                    {
                        booking.price = find_id.Price;
                        booking.ticket_id = "ECO" + "-" + numstring + "-" + numstring2 + "-" + numstring3;
                        booking.total = booking.price * booking.Number_of_passengers - find_id.Price * 10 /
                            100 + (booking.price * booking.Number_of_passengers * rate / 100);
                        find_id.economy_seats = find_id.economy_seats - booking.Number_of_passengers;
                        _con.tbl_airlineticket.Add(booking);
                    }
                    else
                    {

                        TempData["error123"] = "The number of seats is not available";
                        return RedirectToAction("booked_flight");
                    }

                }
                else if (booking.category == "Busniess")
                {

                    if (booking.Number_of_passengers <= find_id.busneiss_seats)
                    {
                        booking.price = find_id.Price;
                        booking.ticket_id = "BUS" + "-" + numstring + "-" + numstring2 + "-" + numstring3;
                        booking.total = booking.price * booking.Number_of_passengers + (booking.price * booking.Number_of_passengers * rate / 100);
                        find_id.busneiss_seats = find_id.busneiss_seats - booking.Number_of_passengers;
                    }
                    else {
                        TempData["error123"] = "The number of seats is not available";
                        return RedirectToAction("booked_flight");
                    }
                }
                var login = HttpContext.Session.GetString("user_session");
                booking.User_id = int.Parse(login);
                booking.baggage = 0;
                booking.Status = 0;
                booking.seat_num = "shp-" + seat_num;
                booking.timing = find_id.Timing;
                booking.city_id = find_id.city_id;
                booking.Country_id = find_id.travel_from;
                booking.city = find_id.cities;
                booking.Country = find_id.travel_to;
                booking.date = find_id.airline_date;
                booking.paid = "due";
                booking.booking_status = "not confrim";
                booking.broadpass = 0;
                booking.flight_name = find_id.Name;
                var gate_number = random.Next(00,99).ToString();
                booking.gate = "A" + gate_number;
                find_id.seat_avaiable = find_id.busneiss_seats + find_id.economy_seats;
               
            }
            else
            {
                booking.total = booking.price * booking.Number_of_passengers;

                return RedirectToAction("booked_flight");
            }
            TempData["error123"] = "The ticket id is " + booking.ticket_id + "" +
                " please save this for your flight";
            _con.tbl_airlineticket.Add(booking);
            _con.SaveChanges();
            return RedirectToAction("booked_flight");
        }
        [HttpGet]
        public IActionResult trackyourflight(string textsraech)
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                List<ticketBooking> booking_ticket = new List<ticketBooking>();
                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                if (string.IsNullOrEmpty(textsraech))
                {

                }
                else
                {
                    booking_ticket = _con.tbl_airlineticket.FromSqlInterpolated($"select * from tbl_airlineticket where ticket_id like '%'+ {textsraech}+'%' or name like '%'+{textsraech}+'%'")
                .ToList();
                }



                mainmodel data = new mainmodel()
                {

                    booking_record = booking_ticket,
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                return RedirectToAction("user_login", "user");

            }
        }
        public IActionResult viewHistory()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {

                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                var flight_details = _con.tbl_airlineticket.Where(e => e.User_id == int.Parse(login)).ToList();
                var pakcage_details = _con.tbl_packagebooking.Where(e => e.User_id == int.Parse(login)).ToList();
                if (flight_details.Count == 0)
                {
                    TempData["errorss"] = "You didnot booked any flight yet";
                }
                mainmodel data = new mainmodel()
                { packages_booked =pakcage_details ,
                    booking_record = flight_details,
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                return RedirectToAction("user_login", "user");

            }

        }
        
        public IActionResult cancel_flight(int id)
        {
            var ticket_details = _con.tbl_airlineticket.Find(id);
            var flight_data = _con.tbl_flightsmanagement.FirstOrDefault(e => e.Id == ticket_details.plane_id);
            if (ticket_details.category== "economy")
            {
                flight_data.economy_seats = flight_data.economy_seats + ticket_details.Number_of_passengers;
            }
            else
            {
                flight_data.busneiss_seats = flight_data.busneiss_seats + ticket_details.Number_of_passengers;

}

            _con.tbl_airlineticket.Remove(ticket_details);
            _con.SaveChanges();
            return RedirectToAction("viewHistory");
        }
        public IActionResult cancel_flightairlines(int id)
        {
            var ticket_details = _con.tbl_airlineticket.Find(id);
            _con.tbl_airlineticket.Remove(ticket_details);
            _con.SaveChanges();
            return RedirectToAction("trackyourflight");
        }
        public IActionResult Packages()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {

                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                var packages = _con.tbl_packages.ToList();
                
                mainmodel data = new mainmodel()
                {
                packages_record=packages,
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                return RedirectToAction("user_login", "user");

            }
        }
        public IActionResult packages_booked(int id)
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {

                var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
                var packages = _con.tbl_packages.Find(id);

                mainmodel data = new mainmodel()
                {
                    packages_data = packages,
                    user_record = user_record
                };
                TempData["error"] = "my";
                return View(data);

            }
            else
            {
                return RedirectToAction("user_login", "user");

            }


        }
        [HttpPost]
        public IActionResult packages_booked(int id, package_booked booked_package)
        {
            var login = HttpContext.Session.GetString("user_session");

            var find_id = _con.tbl_packages.Find(id);
            find_id.Quantity = find_id.Quantity - 1;
            Random random = new Random();
            var number = random.Next(00000,99999).ToString();
            var number1 = random.Next(00000, 99999).ToString();
            var number2 = random.Next(00,99).ToString();
            var number_string = "SAB" + "-" + number + "-" + number1 + "-" + number2;
            booked_package.ticket_id = number_string;
            booked_package.quantity = 1;
            booked_package.package_id=find_id.Id ;
            booked_package.price_package = find_id.Price;
            booked_package.status = 0;
           booked_package.packages_name=find_id.Name;
            booked_package.User_id = int.Parse(login);
            booked_package.total = booked_package.price_package * booked_package.Number_of_passengers;
            _con.tbl_packagebooking.Add(booked_package);
            _con.SaveChanges();
            TempData["error123"] = "The ticket id is " + booked_package.ticket_id + "";
            return RedirectToAction("packages_booked");
        }
        public IActionResult cancel_packages(int id)
        {
            var del = _con.tbl_packagebooking.Find(id);
            var qunatity = _con.tbl_packages.FirstOrDefault(e => e.Id == del.package_id);
            qunatity.Quantity = qunatity.Quantity + del.quantity;
            _con.tbl_packagebooking.Remove(del);
            _con.SaveChanges();
            return RedirectToAction("viewHistory");
        }

         /*broading pass*/
        public IActionResult boradingpass(int id)
        {
            var login = HttpContext.Session.GetString("user_session");


            var user_record = _con.tbl_user.Where(e => e.id == int.Parse(login)).ToList();
            var ticket_details = _con.tbl_airlineticket.FirstOrDefault(t => t.User_id == int.Parse(login) && t.myid == id);
            HtmlToPdf mypdf = new HtmlToPdf();
            string marksheet = System.IO.File.ReadAllText(_evn.WebRootPath + "/htmlpage.html");
            ticketBooking mybooking = new ticketBooking();
            mybooking.name = ticket_details.name;
            mybooking.email = ticket_details.email;
            mybooking.flight_name=ticket_details.flight_name;
            mybooking.seat_num = ticket_details.seat_num;
            mybooking.date = ticket_details.date;
            mybooking.ticket_id=ticket_details.ticket_id;
            mybooking.gate = ticket_details.gate;
            mybooking.category = ticket_details.category;
            mybooking.flight_name=ticket_details.flight_name;
            mybooking.Phone_number = ticket_details.Phone_number;
            mybooking.seat_num = ticket_details.seat_num;
            mybooking.myid = ticket_details.myid;
            mybooking.timing = ticket_details.timing;
            mybooking.city =ticket_details.city;
            marksheet = marksheet.Replace("{{name}}", mybooking.name);
            marksheet = marksheet.Replace("{{class}}", mybooking.category);
            marksheet = marksheet.Replace("{{flight_name}}", mybooking.flight_name);
            marksheet = marksheet.Replace("{{date}}", mybooking.date);
            marksheet = marksheet.Replace("{{gate}}", mybooking.gate);
            marksheet = marksheet.Replace("{{seat}}", mybooking.seat_num);
            marksheet = marksheet.Replace("{{id}}", mybooking.ticket_id);
            marksheet = marksheet.Replace("{{time}}", mybooking.timing);
            marksheet = marksheet.Replace("{{t_id}}", mybooking.ticket_id);
            marksheet = marksheet.Replace("{{city}}", mybooking.city);

            PdfDocument pdf = mypdf.ConvertHtmlString(marksheet);
            var btyes = pdf.Save();

            return File(btyes, "application/pdf", "broading_pass.pdf");


           
        }
    }
}
