using GiaoHangTietKiem.Controllers.Model;
using GiaoHangTietKiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoHangTietKiem.Controllers
{
    public class AdminController : Controller
    {
        GiaohangchatluongContext context = new GiaohangchatluongContext();
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAdmin model)
        {
            TaiKhoan tk = Dataprovider.Instance.DB.TaiKhoans.FirstOrDefault(p => p.TenTK.Equals(model.UserName) && p.MatKhau.Equals(model.Password));
            if (tk != null)
            {
                Session["TaiKhoan"] = tk.TenTK;
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ModelState.AddModelError("", "mk sai");
            }
            return View(model);
        }

        //----------KHÁCH HÀNG----------
        [HttpGet]
        public ActionResult IndexCustomer()
        {
            var listCustomer = context.KhachHangs.ToList();
            return View(listCustomer);
        }

        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(KhachHang kh)
        {
            context.KhachHangs.Add(kh);
            context.SaveChanges();

            return RedirectToAction("IndexCustomer", "Admin");
        }

        [HttpGet]
        public ActionResult DetailsCustomer(string id)
        {
            KhachHang kh = context.KhachHangs.FirstOrDefault(r => r.MaKH == id);
            if (kh == null)
                return HttpNotFound();
            return View(kh);
        }

        [HttpGet]
        public ActionResult EditCustomer(string id)
        {
            KhachHang kh = context.KhachHangs.FirstOrDefault(r => r.MaKH == id);
            if (kh == null)
                return HttpNotFound();
            return View(kh);
        }
        [HttpPost]
        public ActionResult EditCustomer(KhachHang kh)
        {
            KhachHang dbUpdate = context.KhachHangs.FirstOrDefault(r => r.MaKH == kh.MaKH);
            if (dbUpdate != null)
            {
                dbUpdate.TenKH = kh.TenKH;
                dbUpdate.SDT = kh.SDT;
                dbUpdate.DiaChi = kh.DiaChi;
                dbUpdate.GioiTinh = kh.GioiTinh;
                context.SaveChanges();
            }

            return RedirectToAction("IndexCustomer", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteCustomer(string id)
        {
            KhachHang kh = context.KhachHangs.FirstOrDefault(r => r.MaKH == id);
            if (kh != null)
            {
                context.KhachHangs.Remove(kh);
                context.SaveChanges();
            }

            return View(kh);
        }

        //----------KHÁCH NHẬN----------
        [HttpGet]
        public ActionResult IndexRecipients()
        {
            var listrecipients = context.KhachNhans.ToList();
            return View(listrecipients);
        }

        [HttpGet]
        public ActionResult CreateRecipients()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRecipients(KhachNhan kn)
        {
            context.KhachNhans.Add(kn);
            context.SaveChanges();

            return RedirectToAction("IndexRecipients", "Admin");
        }

        [HttpGet]
        public ActionResult DetailsRecipients(string id)
        {
            KhachNhan kn = context.KhachNhans.FirstOrDefault(r => r.MaKN == id);
            if (kn == null)
                return HttpNotFound();
            return View(kn);
        }

        [HttpGet]
        public ActionResult EditRecipients(string id)
        {
            KhachNhan kn = context.KhachNhans.FirstOrDefault(r => r.MaKN == id);
            if (kn == null)
                return HttpNotFound();
            return View(kn);
        }
        [HttpPost]
        public ActionResult EditRecipients(KhachNhan kn)
        {
            KhachNhan dbUpdate = context.KhachNhans.FirstOrDefault(r => r.MaKN == kn.MaKN);
            if (dbUpdate != null)
            {
                dbUpdate.TenKN = kn.MaKN;
                dbUpdate.SDT = kn.SDT;
                dbUpdate.DiaChi = kn.DiaChi;
                dbUpdate.GioiTinh = kn.GioiTinh;
                context.SaveChanges();
            }

            return RedirectToAction("IndexRecipients", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteRecipients(string id)
        {
            KhachNhan kn = context.KhachNhans.FirstOrDefault(r => r.MaKN == id);
            if (kn != null)
            {
                context.KhachNhans.Remove(kn);
                context.SaveChanges();
            }

            return View(kn);
        }

        //----------NHÂN VIÊN----------
        [HttpGet]
        public ActionResult IndexStaff()
        {
            var listStaff = context.NhanViens.ToList();
            return View(listStaff);
        }

        [HttpGet]
        public ActionResult CreateStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStaff(NhanVien nv)
        {
            context.NhanViens.Add(nv);
            context.SaveChanges();

            return RedirectToAction("IndexStaff", "Admin");
        }

        [HttpGet]
        public ActionResult DetailsStaff(string id)
        {
            NhanVien nv = context.NhanViens.FirstOrDefault(r => r.MaNV == id);
            if (nv == null)
                return HttpNotFound();
            return View(nv);
        }

        [HttpGet]
        public ActionResult EditStaff(string id)
        {
            NhanVien nv = context.NhanViens.FirstOrDefault(r => r.MaNV == id);
            if (nv == null)
                return HttpNotFound();
            return View(nv);
        }
        [HttpPost]
        public ActionResult EditStaff(NhanVien nv)
        {
            NhanVien dbUpdate = context.NhanViens.FirstOrDefault(r => r.MaNV == nv.MaNV);
            if (dbUpdate != null)
            {
                dbUpdate.TenNV = nv.TenNV;
                dbUpdate.NgaySinh = nv.NgaySinh;
                dbUpdate.SDT = nv.SDT;
                dbUpdate.DiaChi = nv.DiaChi;
                dbUpdate.GioiTinh = nv.GioiTinh;
                dbUpdate.ChucVu = nv.ChucVu;
                dbUpdate.BacLuong = nv.BacLuong;
                dbUpdate.MaPB = nv.MaPB;
                dbUpdate.MaNK = nv.MaNK;
                context.SaveChanges();
            }

            return RedirectToAction("IndexStaff", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteStaff(string id)
        {
            NhanVien nv = context.NhanViens.FirstOrDefault(r => r.MaNV == id);
            if (nv != null)
            {
                context.NhanViens.Remove(nv);
                context.SaveChanges();
            }

            return View(nv);
        }

        //----------NHÀ KHO----------
        [HttpGet]
        public ActionResult IndexStoreHouse()
        {
            var listStoreHouse = context.NhaKhoes.ToList();
            return View(listStoreHouse);
        }

        [HttpGet]
        public ActionResult CreateStoreHouse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStoreHouse(NhaKho nk)
        {
            context.NhaKhoes.Add(nk);
            context.SaveChanges();

            return RedirectToAction("IndexStoreHouse", "Admin");
        }

        [HttpGet]
        public ActionResult DetailsStoreHouse(string id)
        {
            NhaKho nk = context.NhaKhoes.FirstOrDefault(r => r.MaNK == id);
            if (nk == null)
                return HttpNotFound();
            return View(nk);
        }

        [HttpGet]
        public ActionResult EditStoreHouse(string id)
        {
            NhaKho nk = context.NhaKhoes.FirstOrDefault(r => r.MaNK == id);
            if (nk == null)
                return HttpNotFound();
            return View(nk);
        }
        [HttpPost]
        public ActionResult EditStoreHouse(NhaKho nk)
        {
            NhaKho dbUpdate = context.NhaKhoes.FirstOrDefault(r => r.MaNK == nk.MaNK);
            if (dbUpdate != null)
            {
                dbUpdate.TenNK = nk.TenNK;
                dbUpdate.DienTich = nk.DienTich;
                dbUpdate.SucChua = nk.SucChua;
                dbUpdate.DiaChi = nk.DiaChi;
                dbUpdate.MaKV = nk.MaKV;
                context.SaveChanges();
            }

            return RedirectToAction("IndexStoreHouse", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteStoreHouse(string id)
        {
            NhaKho nk = context.NhaKhoes.FirstOrDefault(r => r.MaNK == id);
            if (nk != null)
            {
                context.NhaKhoes.Remove(nk);
                context.SaveChanges();
            }

            return View(nk);
        }

        //----------CÁC MẶT HÀNG----------
        [HttpGet]
        public ActionResult IndexGoods()
        {
            var listGoods = context.HangHoas.ToList();
            return View(listGoods);
        }

        [HttpGet]
        public ActionResult CreateGoods()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGoods(HangHoa hh)
        {
            context.HangHoas.Add(hh);
            context.SaveChanges();

            return RedirectToAction("IndexGoods", "Admin");
        }

        [HttpGet]
        public ActionResult DetailsGoods(string id)
        {
            HangHoa hh = context.HangHoas.FirstOrDefault(r => r.MaHH == id);
            if (hh == null)
                return HttpNotFound();
            return View(hh);
        }

        [HttpGet]
        public ActionResult EditGoods(string id)
        {
            HangHoa hh = context.HangHoas.FirstOrDefault(r => r.MaHH == id);
            if (hh == null)
                return HttpNotFound();
            return View(hh);
        }
        [HttpPost]
        public ActionResult EditGoods(HangHoa hh)
        {
            HangHoa dbUpdate = context.HangHoas.FirstOrDefault(r => r.MaHH == hh.MaHH);
            if (dbUpdate != null)
            {
                dbUpdate.TenHH = hh.TenHH;
                dbUpdate.MoTa = hh.MoTa;
                dbUpdate.DonVT = hh.DonVT;
                dbUpdate.MaLHH = hh.MaLHH;
                dbUpdate.GiaTien = hh.GiaTien;
                context.SaveChanges();
            }

            return RedirectToAction("IndexGoods", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteGoods(string id)
        {
            HangHoa hh = context.HangHoas.FirstOrDefault(r => r.MaHH == id);
            if (hh != null)
            {
                context.HangHoas.Remove(hh);
                context.SaveChanges();
            }

            return View(hh);
        }

        //----------TUYÊN DƯƠNG----------
        [HttpGet]
        public ActionResult IndexCommend()
        {
            var listCommend = context.TuyenDuongs.ToList();
            return View(listCommend);
        }

        [HttpGet]
        public ActionResult CreateCommend()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCommend(TuyenDuong td)
        {
            context.TuyenDuongs.Add(td);
            context.SaveChanges();

            return RedirectToAction("IndexCommend", "Admin");
        }

        [HttpGet]
        public ActionResult DetailsCommend(string id)
        {
            TuyenDuong td = context.TuyenDuongs.FirstOrDefault(r => r.MaTD == id);
            if (td == null)
                return HttpNotFound();
            return View(td);
        }

        [HttpGet]
        public ActionResult EditCommend(string id)
        {
            TuyenDuong td = context.TuyenDuongs.FirstOrDefault(r => r.MaTD == id);
            if (td == null)
                return HttpNotFound();
            return View(td);
        }
        [HttpPost]
        public ActionResult EditCommend(TuyenDuong td)
        {
            TuyenDuong dbUpdate = context.TuyenDuongs.FirstOrDefault(r => r.MaTD == td.MaTD);
            if (dbUpdate != null)
            {
                dbUpdate.TenTD = td.TenTD;
                dbUpdate.ThoiGian = td.ThoiGian;
                dbUpdate.MaKhoBD = td.MaKhoBD;
                dbUpdate.MaKhoKT = td.MaKhoKT;
                dbUpdate.MaLVC = td.MaLVC;
                context.SaveChanges();
            }

            return RedirectToAction("IndexCommend", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteCommend(string id)
        {
            TuyenDuong td = context.TuyenDuongs.FirstOrDefault(r => r.MaTD == id);
            if (td != null)
            {
                context.TuyenDuongs.Remove(td);
                context.SaveChanges();
            }

            return View(td);
        }

        //----------PHÒNG BAN----------
        [HttpGet]
        public ActionResult IndexDepartment()
        {
            var listDepartment = context.PhongBans.ToList();
            return View(listDepartment);
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(PhongBan pb)
        {
            context.PhongBans.Add(pb);
            context.SaveChanges();

            return RedirectToAction("IndexDepartment", "Admin");
        }

        [HttpGet]
        public ActionResult DetailsDepartment(string id)
        {
            PhongBan pb = context.PhongBans.FirstOrDefault(r => r.MaPB == id);
            if (pb == null)
                return HttpNotFound();
            return View(pb);
        }

        [HttpGet]
        public ActionResult EditDepartment(string id)
        {
            PhongBan pb = context.PhongBans.FirstOrDefault(r => r.MaPB == id);
            if (pb == null)
                return HttpNotFound();
            return View(pb);
        }
        [HttpPost]
        public ActionResult EditDepartment(PhongBan pb)
        {
            PhongBan dbUpdate = context.PhongBans.FirstOrDefault(r => r.MaPB == pb.MaPB);
            if (dbUpdate != null)
            {
                dbUpdate.TenPB = pb.TenPB;
                dbUpdate.NhiemVu = pb.NhiemVu;
                context.SaveChanges();
            }

            return RedirectToAction("IndexDepartment", "Admin");
        }

        [HttpGet]
        public ActionResult DeleteDepartment(string id)
        {
            PhongBan pb = context.PhongBans.FirstOrDefault(r => r.MaPB == id);
            if (pb != null)
            {
                context.PhongBans.Remove(pb);
                context.SaveChanges();
            }

            return View(pb);
        }
    }
}