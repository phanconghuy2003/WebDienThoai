using bandienthoai.Areas.Admin.Models.DAO;
using bandienthoai.Areas.Admin.Models.EF;
using bandienthoai.Common;
using Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class TypeProductController : BaseController
    {
        // GET: Admin/TypeProduct
        [HasCredential(RoleID = "VIEW_TYPEPRODUCT")]
        public ActionResult Index()
        {
           var model= new TypeProductDAO().GetListProduct();
            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "EDIT_TYPEPRODUCT")]
        public ActionResult Edit(long id)
        {
            var dao = new TypeProductDAO();
            var model = new TypeProductDAO().GetTypeProductByID(id);
            ViewBag.LOAISANPHAM_ID = new SelectList(dao.GetListProduct(), "LOAISANPHAM_ID", "TEN_LOAISANPHAM", id);

            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_TYPEPRODUCT")]
        public ActionResult Create(long? selectedId)
        {
            var dao = new TypeProductDAO();
                 ViewBag.LOAISANPHAM_ID = new SelectList(dao.GetListProduct(), "LOAISANPHAM_ID", "TEN_LOAISANPHAM", selectedId);
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "ADD_TYPEPRODUCT")]
        public ActionResult Create(LOAISANPHAM sp)
        {
            if (ModelState.IsValid)
            {

                var dao = new TypeProductDAO();
                var tk = dao.GetByTitle(sp.TEN_LOAISANPHAM);

                if (tk != null)
                {
                    SetAlert("Loại Sản phẩm đã  tồn tại", "fail");
                    return RedirectToAction("Index", "TypeProduct");
                }

         

                var txtContent = Request.Unvalidated.Form.Get("txtContent");

                // encode the data

                // decode the data


                sp.CREATEBY = ((UserLogin)Session[CommonStants.USER_SESSION]).userName;
                sp.CREATDATE = DateTime.Now;
                
          
                if (string.IsNullOrEmpty(sp.GHICHU_LOAISANPHAM))
                {
                    sp.GHICHU_LOAISANPHAM = StringHelper.toUnsignString(sp.TEN_LOAISANPHAM);
                }

                decimal id = dao.Insert(sp);

                if (id > 0)
                {
                  
                    SetAlert("Thêm Thành công", "success");
                    return RedirectToAction("Index", "TypeProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công!");
                }
            }
            return View("Index");

        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_TYPEPRODUCT")]
        public ActionResult Edit(LOAISANPHAM sp)
        {
            if (ModelState.IsValid)
            {
                var dao = new TypeProductDAO();
                var tk = dao.GetByTitle(sp.TEN_LOAISANPHAM);

                if (tk != null)
                {
                    SetAlert("Loại Sản phẩm đã  tồn tại", "fail");
                    return RedirectToAction("Index", "TypeProduct");
                }
           
                sp.MODIFILEDDATE = DateTime.Now;


                if (string.IsNullOrEmpty(sp.GHICHU_LOAISANPHAM))
                {
                    sp.GHICHU_LOAISANPHAM = StringHelper.toUnsignString(sp.TEN_LOAISANPHAM);
                }
              
                bool id = dao.Update(sp);

                if (id==true)
                {

                    SetAlert("Chỉnh sửa Thành công", "success");
                    return RedirectToAction("Index", "TypeProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉnh sửa không thành công!");
                }
            }
            return View("Index");

        }
        [HasCredential(RoleID = "DELETE_TYPEPRODUCT")]
        public JsonResult Delete(int id)
        {
            var dao = new TypeProductDAO();

            var result = false;


            result = dao.Delete(id);
            if (result)
            {
                SetAlert("Xóa thành công", "success");
            }
            else
            {
                ModelState.AddModelError("", "Xóa Thất Bại!");
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}