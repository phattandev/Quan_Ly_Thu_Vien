using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace Quan_Ly_Thu_Vien_Remake
{
    public class TaiLieu
    {
        private string ID;
        public string NXB;
        public int SoBPH;

        public string ID1 { get => ID; set => ID = value; }

        public TaiLieu(string id, string nxb, int soBPH)
        {
            ID1 = id;
            NXB = nxb;
            SoBPH = soBPH;
        }

        public void InfoTaiLieu()
        {
            WriteLine($" + Ma tai lieu: {ID1}; Nha xuat ban: {NXB}; So ban phat hanh: {SoBPH}");
        }
    }

    public class Sach : TaiLieu
    {
        public string TenTacGia;
        public int SoTrang;
        public Sach(string id, string nxb, int soBPH, string tenTG, int soTrang):base(id,nxb,soBPH)
        {
            TenTacGia = tenTG;
            SoTrang = soTrang;
        }
    }

    public class TapChi : TaiLieu
    {
        public int SoPhatHanh;
        public int ThangPhatHanh;
        public TapChi(string id, string nxb, int soBPH, int soPhatHanh, int thangPhatHanh) : base(id, nxb, soBPH)
        {
            SoPhatHanh = soPhatHanh;
            ThangPhatHanh = thangPhatHanh;
        }
    }
    public class Bao : TaiLieu
    {
        public int NgayPhatHanh;
        public Bao(string id, string nxb, int soBPH, int ngayPhatHanh) : base(id, nxb, soBPH)
        {
            NgayPhatHanh = ngayPhatHanh;
        }
    }

    class QuanLy : TaiLieu
    {
        public static int soTaiLieuTrenHeThong = 0;
        public QuanLy(string id, string nxb, int soBPH) : base(id, nxb, soBPH)
        {
        }

        #region add cac loai tai lieu

        public void addSach(ref List<TaiLieu> danhSach)
        {
            Sach sach = new Sach("", "", 0, "", 0);
            Write("Ma tai lieu: ");
            string tempMaTaiLieu;

            do
            {
                tempMaTaiLieu = ReadLine();

                if (danhSach.Exists(item => item.ID1 == tempMaTaiLieu))
                {
                    Write("Ma tai lieu bi trung! Moi nhap lai ma tai liei: ");
                }
                else
                {
                    sach.ID1 = tempMaTaiLieu;
                }
            } while (string.IsNullOrEmpty(sach.ID1));

            Write("Ten nha xuat ban: ");
            sach.NXB = ReadLine();
            Write("So ban phat hanh: ");
            string tempSoBPH = ReadLine();
            while (true)
            {
                if (int.TryParse(tempSoBPH, out sach.SoBPH))
                {
                    break;
                }
                else
                {
                    Write("Nhap sai! Moi nhap lai so ban phat hanh: ");
                    tempSoBPH = ReadLine();
                }
            }
            Write("So trang: ");
            string tempSoTrang = ReadLine();
            while (true)
            {
                if (int.TryParse(tempSoTrang, out sach.SoTrang))
                {
                    break;
                }
                else
                {
                    Write("Nhap sai! Moi nhap lai so ban phat hanh: ");
                    tempSoTrang = ReadLine();
                }
            }
            danhSach.Add(sach);
        }

        public void addTapChi(ref List<TaiLieu> danhSach)
        {
            TapChi tapchi = new TapChi("", "", 0, 0, 0);
            Write("Ma tap tai lieu: ");
            string tempMaTaiLieu;

            do
            {
                tempMaTaiLieu = ReadLine();

                if (danhSach.Exists(item => item.ID1 == tempMaTaiLieu))
                {
                    Write("Ma tai lieu bi trung! Moi nhap lai ma tai lieu: ");
                }
                else
                {
                    tapchi.ID1 = tempMaTaiLieu;
                    break;
                }
            } while (string.IsNullOrEmpty(tapchi.ID1)); // Kiểm tra xem mã tài liệu đã được nhập hay chưa

            Write("Ten nha xuat ban: ");
            tapchi.NXB = ReadLine();
            Write("So ban phat hanh: ");
            string tempSoBPH = ReadLine();
            while (true)
            {
                if (int.TryParse(tempSoBPH, out tapchi.SoBPH))
                {
                    break;
                }
                else
                {
                    Write("Nhap sai! Moi nhap lai so ban phat hanh: ");
                    tempSoBPH = ReadLine();
                }
            }
            Write("So phat hanh (ep): ");
            string tempSoPH = ReadLine();
            while (true)
            {
                if (int.TryParse(tempSoPH, out tapchi.SoPhatHanh))
                {
                    if (tapchi.SoPhatHanh < 0)
                    {
                        Write("Nhap sai! Moi nhap lai so phat hanh (ep): ");
                        tempSoPH = ReadLine();
                    }
                    else break;
                }
                else
                {
                    Write("Nhap sai! Moi nhap lai so phat hanh (ep): ");
                    tempSoPH = ReadLine();
                }
            }

            Write("Thang phat hanh: ");
            string tempThangPH = ReadLine();
            while (true)
            {
                if (int.TryParse(tempThangPH, out tapchi.ThangPhatHanh))
                {
                    if (tapchi.ThangPhatHanh < 1 || tapchi.ThangPhatHanh > 12)
                    {
                        Write("Nhap sai! Moi nhap lai so phat hanh (ep): ");
                        tempThangPH = ReadLine();
                    }
                    else break;
                }
                else
                {
                    Write("Nhap sai! Moi nhap lai so phat hanh (ep): ");
                    tempThangPH = ReadLine();
                }
            }
            danhSach.Add(tapchi);
        }

        public void addBao(ref List<TaiLieu> danhSach)
        {
            Bao bao = new Bao("","",0,0);
            Write("Ma tai lieu: ");
            string tempMaTaiLieu;

            do
            {
                tempMaTaiLieu = ReadLine();

                if (danhSach.Exists(item => item.ID1 == tempMaTaiLieu))
                {
                    Write("Ma tai lieu bi trung! Moi nhap lai ma tai liei: ");
                }
                else
                {
                    bao.ID1 = tempMaTaiLieu;
                }
            } while (string.IsNullOrEmpty(bao.ID1));

            Write("Ten nha xuat ban: ");
            bao.NXB = ReadLine();
            Write("So ban phat hanh: ");
            string tempSoBPH = ReadLine();
            while (true)
            {
                if (int.TryParse(tempSoBPH, out bao.SoBPH))
                {
                    break;
                }
                else
                {
                    Write("Nhap sai! Moi nhap lai so ban phat hanh: ");
                    tempSoBPH = ReadLine();
                }
            }
            Write("Ngay phat hanh: ");
            string tempNgayPH = ReadLine();
            while (true)
            {
                if (int.TryParse(tempNgayPH, out bao.NgayPhatHanh))
                {
                    if (bao.NgayPhatHanh < 1 || bao.NgayPhatHanh > 31)
                    {
                        Write("Nhap sai! Moi nhap lai ngay phat hanh: ");
                        tempNgayPH = ReadLine();
                    }
                    else break;
                }
                else
                {
                    Write("Nhap sai! Moi nhap lai ngay phat hanh: ");
                    tempNgayPH = ReadLine();
                }
            }
            danhSach.Add(bao);
        }

        #endregion
        public void nhap(ref List<TaiLieu> danhSach)
        {
            WriteLine("----Menu Tai Lieu----");
            WriteLine("1. Sach");
            WriteLine("2. Tap chi");
            WriteLine("3. Bao");
            WriteLine("4. Quay lai menu chinh.");
            WriteLine("5. Dung lai; Thoat chuong trinh.");
            WriteLine("--------------------");
            Write("Moi chon: ");
            string tempChoose = ReadLine();
            int choose;
            while (true)
            {
                if (int.TryParse(tempChoose, out choose))
                {
                    if (choose < 1 || choose > 5)
                    {
                        Write("Chon sai! Moi chon lai: ");
                        tempChoose = ReadLine();
                    }
                    else break;
                }
                else
                {
                    Write("Chon sai! Moi chon lai: ");
                    tempChoose = ReadLine();
                }
            }
            switch (choose)
            {
                case 1:
                    Clear();
                    addSach(ref danhSach);
                    soTaiLieuTrenHeThong++;
                    break;
                case 2:
                    Clear();
                    addTapChi(ref danhSach);
                    soTaiLieuTrenHeThong++;
                    break;
                case 3:
                    Clear();
                    addBao(ref danhSach);
                    soTaiLieuTrenHeThong++;
                    break;
                case 4:
                    Clear();

                    break;
                case 5:
                    Clear();
                    WriteLine("Thoat chuong trinh.");
                    break;
                default:
                    break;
            }
        }

        public void xuat(List<TaiLieu> danhSach)
        {
            WriteLine($"Tong so tai lieu: {QuanLy.soTaiLieuTrenHeThong}");
            foreach (var item in danhSach)
            {
                if(item is Sach)
                {
                    Write("- Sach: ");
                    item.InfoTaiLieu();
                    Sach sach = (Sach)item;
                    WriteLine($"           + Ten tac gia: {sach.TenTacGia}; So trang: {sach.SoTrang}");
                }
                else if (item is TapChi)
                {
                    Write("- Tai Lieu: ");
                    item.InfoTaiLieu();
                    TapChi tapchi = (TapChi)item;
                    WriteLine($"             + So phat hanh: {tapchi.SoPhatHanh}; Thang phat hanh: {tapchi.ThangPhatHanh}");
                }
                else if (item is Bao)
                {
                    Write("- Bao: ");
                    item.InfoTaiLieu();
                    Bao bao = (Bao)item;
                    WriteLine($"        + Ngay phat hanh: {bao.NgayPhatHanh}");
                }
            }
        }

        public void xoa(ref List<TaiLieu> danhSach)
        {
            Write("Nhap ma tai lieu can xoa: ");
            string taiLieuCanXoa = ReadLine();
            bool flag = false;
            for(int i=0;i<danhSach.Count;i++)
            {
                if (danhSach[i].ID1 == taiLieuCanXoa)
                {
                    danhSach.RemoveAt(i);
                    flag = true;
                    soTaiLieuTrenHeThong--;
                }
            }
            if(flag == true)
                WriteLine($"Da xoa tai lieu co ma tai lieu {taiLieuCanXoa}.");
            else
                WriteLine($"Khong tim thay tai lieu co ma tai lieu {taiLieuCanXoa}");
        }


        public void timKiem (List<TaiLieu> danhSach)
        {
            Write("Nhap ma tai lieu can tim: ");
            string taiLieuCanTim = ReadLine();
            bool flag = false;
            foreach (var item in danhSach)
            {
                if(item.ID1 == taiLieuCanTim)
                {
                    if (item is Sach)
                    {
                        flag = true;
                        Write("- Sach: ");
                        item.InfoTaiLieu();
                        Sach sach = (Sach)item;
                        WriteLine($"          + Ten tac gia: {sach.TenTacGia}; So trang: {sach.SoTrang}");
                    }
                    else if (item is TaiLieu)
                    {
                        flag = true;
                        Write("- Tai Lieu: ");
                        item.InfoTaiLieu();
                        TapChi tapchi = (TapChi)item;
                        WriteLine($"             + So phat hanh: {tapchi.SoPhatHanh}; Thang phat hanh: {tapchi.ThangPhatHanh}");
                    }
                    else if (item is Bao)
                    {
                        flag = true;
                        WriteLine("- Bao: ");
                        item.InfoTaiLieu();
                        Bao bao = (Bao)item;
                        WriteLine($"        + Ngay phat hanh: {bao.NgayPhatHanh}");
                    }
                }
            }
            if (flag == false)
                WriteLine($"Khong tim thay tai lieu co ma tai lieu {taiLieuCanTim}");
        }

        public void Menu(ref List<TaiLieu> danhSach)
        {
            WriteLine("----Menu Chinh----");
            WriteLine("1. Them tai lieu.");
            WriteLine("2. Xem tat ca tai lieu.");
            WriteLine("3. Xoa tai lieu.");
            WriteLine("4. Tim kiem tai lieu.");
            WriteLine("5. Dung lai; Thoat chuong trinh.");
            Write("Moi chon: ");
            string tempChoose = ReadLine();
            int choose;
            while (true)
            {
                if (int.TryParse(tempChoose, out choose))
                {
                    if (choose < 1 || choose > 5)
                    {
                        Write("Chon sai! Moi chon lai: ");
                        tempChoose = ReadLine();
                    }
                    else break;
                }
                else
                {
                    Write("Chon sai! Moi chon lai: ");
                    tempChoose = ReadLine();
                }
            }
            switch (choose)
            {
                case 1:
                    Clear();
                    nhap(ref danhSach);
                    Menu(ref danhSach);
                    break;
                case 2:
                    Clear();
                    xuat(danhSach);
                    Menu(ref danhSach);
                    break;
                case 3:
                    Clear();
                    xoa(ref danhSach);
                    Menu(ref danhSach);
                    break;
                case 4:
                    Clear();
                    timKiem(danhSach);
                    Menu(ref danhSach);
                    break;
                case 5:
                    Clear();
                    WriteLine("Thoat chuong trinh.");
                    break;
                default:
                    break;
            }
        }
    }
}
