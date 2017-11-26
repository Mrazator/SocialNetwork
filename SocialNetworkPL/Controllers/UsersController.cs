using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;
using X.PagedList;

namespace SocialNetworkPL.Controllers
{
    public class UsersController : Controller
    {
        public const int PageSize = 10;
        private const string FilterSessionKey = "userFilter";

        public UserFacade UserFacade { get; set; }
        public UserDetailFacade UserDetailFacade { get; set; }

        [System.Web.Mvc.Route("/Users/GetBySubname?subname=M")]
        public async Task<ActionResult> Index([FromUri] string subname, int page = 1)
        {
            var filter = Session[FilterSessionKey] as UserFilterDto ?? new UserFilterDto() { PageSize = PageSize };
            filter.RequestedPageNumber = page;
            filter.SubName = subname;

            var users = await UserFacade.GetUsersContainingSubNameAsync(filter.SubName);
            var model = InitializeProductListViewModel(filter,users);

            return View("UserListView", model);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Index(UsersListViewModel model)
        {
            model.Filter.PageSize = PageSize;
            Session[FilterSessionKey] = model.Filter;

            var result = await UserFacade.GetUsersContainingSubNameAsync(model.Filter.SubName);
            var newModel = InitializeProductListViewModel(model.Filter, result);
            return View("UserListView", newModel);
        }

        private UsersListViewModel InitializeProductListViewModel(UserFilterDto filter, IEnumerable<UserDto> users)
        {
            var userDtos = users as IList<UserDto> ?? users.ToList();

            return new UsersListViewModel
            {
                Users = new StaticPagedList<UserDto>(userDtos, filter.RequestedPageNumber ?? 1, PageSize, userDtos.ToList().Count),
                Filter = filter
            };
        }

        // GET: Users/Details/5
        public async  Task<ActionResult> Details(int id)
        {
            var user = await UserFacade.GetAsync(id);
            return View("Detail", user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Create(UserDto user)
        {
            try
            {
                await UserFacade.CreateAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Edit(int id, UserDto user)
        {
            try
            {
                await UserFacade.UpdateAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await UserFacade.DeleteAsync(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
