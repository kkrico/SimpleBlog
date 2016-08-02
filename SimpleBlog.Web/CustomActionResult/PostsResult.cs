using System;
using System.Web.Mvc;

namespace SimpleBlog.Web.CustomActionResult
{
    public class PostsResult : ViewResultBase
    {
        public PostsResult(string nomeView, string nomePartial, object model)
        {
            ViewName = nomeView;    // Prop viewName vem da classe Base. O valor dela o mvc dela faz um lazy load maroto
            PartialViewName = nomePartial;
            ViewData.Model = model;
        }

        #region Campos privados
        private string _masterName;
        private string _partialViewName;
        #endregion

        #region Propriedades
        public string PartialViewName
        {
            get { return _partialViewName ?? String.Concat(ViewName, "PartialView"); }
            set { _partialViewName = value; }
        }
        public string MasterName
        {
            get { return _masterName ?? String.Empty; }
            set { _masterName = value; }
        }
        #endregion

        protected override ViewEngineResult FindView(ControllerContext context)
        {
            var isAjax = context.RequestContext.HttpContext.Request.IsAjaxRequest();
            if (isAjax)
            {
                return ViewEngineCollection.FindPartialView(context, PartialViewName);
            }

            return ViewEngineCollection.FindView(context, ViewName, MasterName);
        }
    }
}