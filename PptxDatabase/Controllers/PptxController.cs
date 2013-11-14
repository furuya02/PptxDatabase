using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PptxDatabase.Models;

namespace PptxDatabase.Controllers
{
    public class PptxController : Controller
    {

        DataFileRepository _pptxRepository = new DataFileRepository();

        //
        // GET: /Pptx/

        public ActionResult Index()
        {

            return View(_pptxRepository.GetAll());
        }

        //
        // GET: /Pptx/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pptx/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pptx/Create

//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here
//
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

        [HttpPost]
        public ActionResult Create(Datafile datafile) {
            try {
                if (!ModelState.IsValid) {
                    return View(datafile);
                }

                // アップロードされたファイルを取得
                var file = Request.Files["File"];

                // ファイルを検証
                if (file == null) {
                    ModelState.AddModelError("File", "ファイルを選択してください。");
                    return View(datafile);
                }

                //if (file.ContentType != "application/vnd.openxmlformats-officedocument.presentationml.presentation") {
                //    ModelState.AddModelError("File", "ファイルの形式が不正です。");
                //    return View(pptx);
                //}

                // 作成、更新日時をセット
                datafile.CreatedAt = datafile.UpdatedAt = DateTime.Now;

                //ファイル名
                datafile.Filename = file.FileName;

                // データベースへ追加、反映
                _pptxRepository.Add(datafile);
                _pptxRepository.Save();

                // ファイルを保存
                var path = Server.MapPath(string.Format("~/Files/{0}", file.FileName));

                file.SaveAs(path);

                return RedirectToAction("Index");
            } catch {
                return View(datafile);
            }
        }

        //
        // GET: /Pptx/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pptx/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pptx/Delete/5

        public ActionResult Delete(int id)
        {
            _pptxRepository.Del(id);
            _pptxRepository.Save();
            return RedirectToAction("Index",_pptxRepository.GetAll());
        }

        //
        // POST: /Pptx/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
