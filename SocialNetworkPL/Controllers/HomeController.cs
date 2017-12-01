using System.Threading.Tasks;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;
using X.PagedList;

namespace SocialNetworkPL.Controllers
{
    public class HomeController : Controller
    {
        public const int PageSize = 10;
        private const string FilterSessionKey = "postFilter";

        public PostFacade PostFacade { get; set; }
        public UserFacade UserFacade { get; set; }

        // GET: Posts
        public async Task<ActionResult> Index(int page = 1)
        {
            var filter = Session[FilterSessionKey] as PostFilterDto ?? new PostFilterDto {PageSize = PageSize};
            filter.RequestedPageNumber = page;

            var result = await PostFacade.GetPostsAsync(filter);
            var model = InitializeProductListViewModel(result);

            return View("Index", model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(PostListModel model)
        {
            model.Filter.PageSize = PageSize;
            Session[FilterSessionKey] = model.Filter;

            var result = await PostFacade.GetPostsAsync(model.Filter);
            var newModel = InitializeProductListViewModel(result);
            return View("Index", newModel);
        }


        private PostListModel InitializeProductListViewModel(QueryResultDto<PostDto, PostFilterDto> result)
        {
            return new PostListModel
            {
                Posts = new StaticPagedList<PostDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize,
                    (int) result.TotalItemsCount),
                Filter = result.Filter
            };
        }

        // GET: Posts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await PostFacade.GetAsync(id);
            return View("PostDetailView", model);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        public async Task<ActionResult> Create(PostDto post)
        {
            try
            {
                await PostFacade.CreateAsync(post);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, PostDto post)
        {
            try
            {
                await PostFacade.UpdateAsync(post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Posts/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                await PostFacade.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}