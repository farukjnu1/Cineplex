using Cineplex.Models;
using Cineplex.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Cineplex.ViewModels.HallVm;

namespace Cineplex.Controllers
{
    public class ShowsController : Controller
    {
        CineplexDbContext _ctx = new CineplexDbContext();

        // GET: ShowsController
        public ActionResult Index()
        {
            return View(_ctx.Shows.ToList());
        }

        // GET: ShowsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShowsController/Create
        public ActionResult Create()
        {
            var listMovie = _ctx.Movies.ToList();
            var movies = new List<SelectListItem>();
            foreach (var oMovie in listMovie) 
            {
                var movie = new SelectListItem();
                movie.Value = oMovie.MovieId.ToString();
                movie.Text = oMovie.MovieName;
                movies.Add(movie);
            }
            var listHall = _ctx.Halls.ToList();
            var halls = new List<SelectListItem>();
            foreach (var oHall in listHall)
            {
                var hall = new SelectListItem();
                hall.Value = oHall.HallId.ToString();
                hall.Text = oHall.HallName;
                halls.Add(hall);
            }
            var model = new ShowVm();
            model.Movies = movies;
            model.Halls = halls;
            return View(model);
        }

        // POST: ShowsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new Show();
                model.ShowStart = Convert.ToDateTime(collection["ShowStart"]);
                model.ShowEnd = Convert.ToDateTime(collection["ShowEnd"]);
                model.ShowName = Convert.ToString(collection["ShowName"]);
                model.HallId = Convert.ToInt32(collection["HallId"]);
                model.MovieId = Convert.ToInt32(collection["MovieId"]);
                _ctx.Shows.Add(model);
                _ctx.SaveChanges();
                var listShowDetail = new List<ShowDetail>();
                var listSeat = (from x in _ctx.SeatPlans where x.HallId == model.HallId select x).ToList();
                foreach (var seat in listSeat) 
                {
                    var oShowDetail = new ShowDetail();
                    oShowDetail.IsBooked = false;
                    oShowDetail.HallId = model.HallId;
                    oShowDetail.CustomerId = null;
                    oShowDetail.SeatNumber = null;
                    oShowDetail.ShowId = model.ShowId;
                    oShowDetail.SeatNumber = seat.SeatNumber;
                        
                    listShowDetail.Add(oShowDetail);
                }
                _ctx.ShowDetails.AddRange(listShowDetail);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowsController/Edit/5
        public ActionResult Edit(int id)
        {
            var listMovie = _ctx.Movies.ToList();
            var movies = new List<SelectListItem>();
            foreach (var oMovie in listMovie)
            {
                var movie = new SelectListItem();
                movie.Value = oMovie.MovieId.ToString();
                movie.Text = oMovie.MovieName;
                movies.Add(movie);
            }
            var listHall = _ctx.Halls.ToList();
            var halls = new List<SelectListItem>();
            foreach (var oHall in listHall)
            {
                var hall = new SelectListItem();
                hall.Value = oHall.HallId.ToString();
                hall.Text = oHall.HallName;
                halls.Add(hall);
            }
            var model = new ShowVm();
            model.Movies = movies;
            model.Halls = halls;
            var oShow = (from x in _ctx.Shows where x.ShowId == id select x).FirstOrDefault();
            if (oShow != null)
            {
                model.ShowStart = oShow.ShowStart;
                model.ShowEnd = oShow.ShowEnd;
                model.ShowId = oShow.ShowId;    
                model.ShowName = oShow.ShowName;
                model.HallId = oShow.HallId;
                model.MovieId = oShow.MovieId;
            }
            return View(model);
        }

        // POST: ShowsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var model = (from x in _ctx.Shows where x.ShowId == id select x).FirstOrDefault();
                if (model != null) 
                {
                    model.ShowStart = Convert.ToDateTime(collection["ShowStart"]);
                    model.ShowEnd = Convert.ToDateTime(collection["ShowEnd"]);
                    model.ShowName = Convert.ToString(collection["ShowName"]);
                    model.HallId = Convert.ToInt32(collection["HallId"]);
                    model.MovieId = Convert.ToInt32(collection["MovieId"]);
                    
                    _ctx.SaveChanges();

                    var listShowDetailRem = (from x in _ctx.ShowDetails where x.ShowId == model.ShowId select x).ToList();
                    if (listShowDetailRem.Count > 0)
                    {
                        _ctx.ShowDetails.RemoveRange(listShowDetailRem);
                        _ctx.SaveChanges();
                    }

                    var listShowDetail = new List<ShowDetail>();
                    var listSeat = (from x in _ctx.SeatPlans where x.HallId == model.HallId select x).ToList();
                    foreach (var seat in listSeat)
                    {
                        var oShowDetail = new ShowDetail();
                        oShowDetail.IsBooked = false;
                        oShowDetail.HallId = model.HallId;
                        oShowDetail.CustomerId = null;
                        oShowDetail.SeatNumber = null;
                        oShowDetail.ShowId = model.ShowId;
                        oShowDetail.SeatNumber = seat.SeatNumber;

                        listShowDetail.Add(oShowDetail);
                    }
                    _ctx.ShowDetails.AddRange(listShowDetail);
                    _ctx.SaveChanges();
                }
                
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowsController/Edit/5
        public ActionResult EditTicket(int id)
        {
            var listMovie = _ctx.Movies.ToList();
            var movies = new List<SelectListItem>();
            foreach (var oMovie in listMovie)
            {
                var movie = new SelectListItem();
                movie.Value = oMovie.MovieId.ToString();
                movie.Text = oMovie.MovieName;
                movies.Add(movie);
            }
            var listHall = _ctx.Halls.ToList();
            var halls = new List<SelectListItem>();
            foreach (var oHall in listHall)
            {
                var hall = new SelectListItem();
                hall.Value = oHall.HallId.ToString();
                hall.Text = oHall.HallName;
                halls.Add(hall);
            }
            var model = new ShowVm();
            model.Movies = movies;
            model.Halls = halls;
            var oShow = (from x in _ctx.Shows where x.ShowId == id select x).FirstOrDefault();
            if (oShow != null)
            {
                model.ShowStart = oShow.ShowStart;
                model.ShowEnd = oShow.ShowEnd;
                model.ShowId = oShow.ShowId;
                model.ShowName = oShow.ShowName;
                model.HallId = oShow.HallId;
                model.MovieId = oShow.MovieId;
            }

            HallVm oHallVm = new HallVm();
            var aHall = _ctx.Halls.Where(x => x.HallId == model.HallId).FirstOrDefault();
            if (aHall != null)
            {
                oHallVm.HallId = aHall.HallId;
                oHallVm.HallName = aHall.HallName;
                oHallVm.Row = aHall.Row;
                oHallVm.Column = aHall.Column;
                List<SeatPlanVm> listSeatPlanVm = new List<SeatPlanVm>();
                var listSeatPlan = _ctx.SeatPlans.Where(x => x.HallId == aHall.HallId).ToList();
                foreach (var seatPlan in listSeatPlan)
                {
                    SeatPlanVm oSeatPlanVm = new SeatPlanVm();
                    oSeatPlanVm.Price = seatPlan.Price;
                    oSeatPlanVm.SeatNumber = seatPlan.SeatNumber;
                    oSeatPlanVm.RowNumber = seatPlan.RowNumber;
                    oSeatPlanVm.HallId = aHall.HallId;

                    listSeatPlanVm.Add(oSeatPlanVm);
                }
                oHallVm.SeatPlans = listSeatPlanVm;
            }
            model.Hall = oHallVm;

            var showDetails = (from x in _ctx.ShowDetails where x.ShowId == id select x).ToList();
            var showDetailVmList = new List<ShowDetailVm>();
            foreach (var showDetail in showDetails)
            {
                var showDetailVm = new ShowDetailVm();
                showDetailVm.ShowDetailsId = showDetail.ShowDetailsId;
                showDetailVm.SeatNumber = showDetail.SeatNumber;
                showDetailVm.CustomerId = showDetail.CustomerId;
                showDetailVm.HallId = showDetail.HallId;
                showDetailVm.ShowId = showDetail.ShowId;
                showDetailVm.IsBooked = showDetail.IsBooked;
                showDetailVmList.Add(showDetailVm);
            }
            model.ShowDetails = showDetailVmList;

            return View(model);
        }

        public ActionResult BuyTicket(int id)
        {
            var listMovie = _ctx.Movies.ToList();
            var movies = new List<SelectListItem>();
            foreach (var oMovie in listMovie)
            {
                var movie = new SelectListItem();
                movie.Value = oMovie.MovieId.ToString();
                movie.Text = oMovie.MovieName;
                movies.Add(movie);
            }
            var listHall = _ctx.Halls.ToList();
            var halls = new List<SelectListItem>();
            foreach (var oHall in listHall)
            {
                var hall = new SelectListItem();
                hall.Value = oHall.HallId.ToString();
                hall.Text = oHall.HallName;
                halls.Add(hall);
            }
            var model = new ShowVm();
            model.Movies = movies;
            model.Halls = halls;
            var oShow = (from x in _ctx.Shows where x.ShowId == id select x).FirstOrDefault();
            if (oShow != null)
            {
                model.ShowStart = oShow.ShowStart;
                model.ShowEnd = oShow.ShowEnd;
                model.ShowId = oShow.ShowId;
                model.ShowName = oShow.ShowName;
                model.HallId = oShow.HallId;
                model.MovieId = oShow.MovieId;
            }
            var showDetails = (from x in _ctx.ShowDetails where x.ShowId == id select x).ToList();
            var showDetailVmList = new List<ShowDetailVm>();
            foreach (var showDetail in showDetails) 
            {
                var showDetailVm = new ShowDetailVm();
                showDetailVm.ShowDetailsId = showDetail.ShowDetailsId;
                showDetailVm.SeatNumber = showDetail.SeatNumber;
                showDetailVm.CustomerId = showDetail.CustomerId;
                showDetailVm.HallId = showDetail.HallId;
                showDetailVm.ShowId = showDetail.ShowId;
                showDetailVm.IsBooked = showDetail.IsBooked;
                showDetailVmList.Add(showDetailVm);
            }
            model.ShowDetails = showDetailVmList;

            HallVm oHallVm = new HallVm();
            var aHall = _ctx.Halls.Where(x => x.HallId == model.HallId).FirstOrDefault();
            if (aHall != null)
            {
                oHallVm.HallId = aHall.HallId;
                oHallVm.HallName = aHall.HallName;
                oHallVm.Row = aHall.Row;
                oHallVm.Column = aHall.Column;
                List<SeatPlanVm> listSeatPlanVm = new List<SeatPlanVm>();
                var listSeatPlan = _ctx.SeatPlans.Where(x => x.HallId == aHall.HallId).ToList();
                foreach (var seatPlan in listSeatPlan)
                {
                    SeatPlanVm oSeatPlanVm = new SeatPlanVm();
                    oSeatPlanVm.Price = seatPlan.Price;
                    oSeatPlanVm.SeatNumber = seatPlan.SeatNumber;
                    oSeatPlanVm.RowNumber = seatPlan.RowNumber;
                    oSeatPlanVm.HallId = aHall.HallId;

                    listSeatPlanVm.Add(oSeatPlanVm);
                }
                oHallVm.SeatPlans = listSeatPlanVm;
            }

            model.Hall = oHallVm;

            return View(model);
        }

        // GET: ShowsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShowsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
