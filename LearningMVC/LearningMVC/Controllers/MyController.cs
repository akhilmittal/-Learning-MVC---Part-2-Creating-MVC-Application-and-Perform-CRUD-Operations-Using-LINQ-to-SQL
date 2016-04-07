#region Using Namespaces
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc; 
#endregion

namespace LearningMVC.Controllers
{
    /// <summary>
    /// My Controller to perform CRUD operations in MVC with the help of LINQ to SQL.
    /// </summary>
    public class MyController : Controller
    {
        #region Display...
        /// <summary>
        /// Get Action for index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var dbContext = new MyDBDataContext();
            var userList = from user in dbContext.Users select user;
            var users = new List<LearningMVC.Models.User>();
            if (userList.Any())
            {
                foreach (var user in userList)
                {
                    users.Add(new LearningMVC.Models.User() { UserId = user.UserId, Address = user.Address, Company = user.Company, FirstName = user.FirstName, LastName = user.LastName, Designation = user.Designation, EMail = user.EMail, PhoneNo = user.PhoneNo });
                }
            }
            ViewBag.FirstName = "My First Name";
            ViewData["FirstName"] = "My First Name";
            if(TempData.Any())
            {
                var tempData = TempData["TempData Name"];
            }
            return View(users);
        }

        /// <summary>
        /// Get Action for Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            var dbContext = new MyDBDataContext();
            var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
            var user = new LearningMVC.Models.User();
            if (userDetails != null)
            {
                user.UserId = userDetails.UserId;
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.Address = userDetails.Address;
                user.PhoneNo = userDetails.PhoneNo;
                user.EMail = userDetails.EMail;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
            }
            return View(user);
        } 
        #endregion

        #region Create...
        /// <summary>
        /// Get Action for Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Action for Create
        /// </summary>
        /// <param name="userDetails"> </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(LearningMVC.Models.User userDetails)
        {
            try
            {
                var dbContext = new MyDBDataContext();
                var user = new User();
                if (userDetails != null)
                {
                    user.UserId = userDetails.UserId;
                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.Address = userDetails.Address;
                    user.PhoneNo = userDetails.PhoneNo;
                    user.EMail = userDetails.EMail;
                    user.Company = userDetails.Company;
                    user.Designation = userDetails.Designation;
                }
                dbContext.Users.InsertOnSubmit(user);
                dbContext.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
        #endregion

        #region Edit...
        /// <summary>
        /// Get Action for Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            var dbContext = new MyDBDataContext();
            var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
            var user = new LearningMVC.Models.User();
            if (userDetails != null)
            {
                user.UserId = userDetails.UserId;
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.Address = userDetails.Address;
                user.PhoneNo = userDetails.PhoneNo;
                user.EMail = userDetails.EMail;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
            }
            return View(user);
        }

        /// <summary>
        /// Post Action for Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int? id, LearningMVC.Models.User userDetails)
        {
            TempData["TempData Name"] = "Akhil";

            try
            {
                var dbContext = new MyDBDataContext();
                var user = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                if (user != null)
                {
                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.Address = userDetails.Address;
                    user.PhoneNo = userDetails.PhoneNo;
                    user.EMail = userDetails.EMail;
                    user.Company = userDetails.Company;
                    user.Designation = userDetails.Designation;
                    dbContext.SubmitChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
        #endregion

        #region Delete...
        /// <summary>
        /// Get Action for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            var dbContext = new MyDBDataContext();
            var user = new LearningMVC.Models.User();
            var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
            if (userDetails != null)
            {
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.Address = userDetails.Address;
                user.PhoneNo = userDetails.PhoneNo;
                user.EMail = userDetails.EMail;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
            }
            return View(user);
        }

        /// <summary>
        /// Post Action for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDetails"> </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int? id, LearningMVC.Models.User userDetails)
        {
            try
            {
                var dbContext = new MyDBDataContext();
                var user = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                if (user != null)
                {
                    dbContext.Users.DeleteOnSubmit(user);
                    dbContext.SubmitChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
        #endregion
    }
}
