using static System.Console;
using Quan_Ly_Thu_Vien_Remake;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaiLieu> danhSach = new List<TaiLieu>();
            QuanLy quanLy = new QuanLy("","",0); // Tạo một thể hiện của lớp QuanLy
            quanLy.Menu(ref danhSach);



        }
    }
}