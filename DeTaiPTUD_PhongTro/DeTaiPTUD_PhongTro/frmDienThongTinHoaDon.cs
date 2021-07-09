using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiPTUD_PhongTro
{
    public partial class frmDienThongTinHoaDon : Form
    {
        String maPhong;
        decimal giaPhong;
        int maNhanVien;
        DateTime hdSauCung;
        public frmDienThongTinHoaDon(String MaPhong, decimal Giathue, int MaNV, DateTime HDSauCung)
        {
            InitializeComponent();
            maPhong = MaPhong;
            giaPhong = Giathue;
            maNhanVien = MaNV;
            hdSauCung = HDSauCung;
        }

        clsQLHoaDon clshd;
        clsChiTietHoaDon clsCTHD;
        clsQLPhieuThue clspt;
        private void FrmDienThongTinHoaDon_Load(object sender, EventArgs e)
        {
            clshd = new clsQLHoaDon();
            clsCTHD = new clsChiTietHoaDon();
            clspt = new clsQLPhieuThue();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult HoiThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (HoiThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        tblHoaDon TaoHoaDon()
        {
            tblHoaDon hd = new tblHoaDon();
            hd.maHD = clshd.LayDuLieu().autoMaHD();
            hd.maNV = maNhanVien;
            hd.ngayLap = DateTime.Now;
            hd.tinhTrangHD = false;
            hd.ghiChu = "";
            hd.ngayCanLap = dtgThangCanLap.Value;
            return hd;
        }

        

        tblCT_HoaDon TaoCTHoaDon(string maHD)
        {
            tblCT_HoaDon cthd = new tblCT_HoaDon();
            cthd.maHD = maHD;
            cthd.maPhieuThue = clspt.LayMaPhieuThueDauTien(maPhong);
            cthd.tienDien = Convert.ToDecimal(txtTienDien.Text);
            cthd.tienNuoc = Convert.ToDecimal(txtTienNuoc.Text);
            cthd.phuPhi = Convert.ToDecimal(txtPhuPhi.Text);
            cthd.tienWifi = Convert.ToDecimal(txtTienWifi.Text);
            cthd.tienGuiXe = Convert.ToDecimal(txtTienGiuXe.Text);
            cthd.TienPhong = giaPhong;
            return cthd;
        }

        public void GenerateHDPDF(tblHoaDon hoaDon, tblCT_HoaDon cthoaDon)
        {
            var pt = clspt.LayDuLieuPhieuThue(maPhong);

            Document document = new Document();
            DateTime now = DateTime.Now;
            var fileName = "hoadon"+"_"+pt.FirstOrDefault().maPhong.ToString()+"_"+ now.ToString("yyyyMMddHHmmss");
            PdfWriter.GetInstance(document, new FileStream("E:/Phat Trien Ung Dung/InHoaDon/" + fileName + ".pdf", FileMode.Create));
            document.Open();

            BaseFont bf = BaseFont.CreateFont("C:/Windows/Fonts/Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Paragraph para = new Paragraph("HÓA ĐƠN", new iTextSharp.text.Font(bf, 22));

            Paragraph paddingSpace = new Paragraph("      ", new iTextSharp.text.Font(bf, 30));

            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 12);

            PdfPTable tSV = new PdfPTable(4);
            float[] widthsv = new float[] { 100f, 80f, 80f, 140f };
            tSV.TotalWidth = 420;

            tSV.SetWidths(widthsv);
            tSV.LockedWidth = true;
            tSV.DefaultCell.Border = 1;
            tSV.DefaultCell.MinimumHeight = 30;
            PdfPCell pCell1 = new PdfPCell(new Phrase("Tên SV", fontNormal));
            PdfPCell pCell2 = new PdfPCell(new Phrase("SĐT", fontNormal));
            PdfPCell pCell3 = new PdfPCell(new Phrase("CMND", fontNormal));
            PdfPCell pCell4 = new PdfPCell(new Phrase("Trường", fontNormal));
            pCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            pCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
            pCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            pCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
            pCell1.MinimumHeight = 30;
            pCell2.MinimumHeight = 30;
            pCell3.MinimumHeight = 30;
            pCell4.MinimumHeight = 30;
            tSV.AddCell(pCell1);
            tSV.AddCell(pCell2);
            tSV.AddCell(pCell3);
            tSV.AddCell(pCell4);

            foreach (var item in pt)
            {
                PdfPCell pCell1Value = new PdfPCell(new Phrase(item.tblSinhVien.tenSV.ToString(), fontNormal));
                PdfPCell pCell2Value = new PdfPCell(new Phrase(item.tblSinhVien.SDT.ToString(), fontNormal));
                PdfPCell pCell3Value = new PdfPCell(new Phrase(item.tblSinhVien.soCMND.ToString(), fontNormal));
                PdfPCell pCell4Value = new PdfPCell(new Phrase(item.tblSinhVien.tblTruong.tenTruong.ToString(), fontNormal));
                pCell1Value.VerticalAlignment = Element.ALIGN_MIDDLE;
                pCell2Value.VerticalAlignment = Element.ALIGN_MIDDLE;
                pCell3Value.VerticalAlignment = Element.ALIGN_MIDDLE;
                pCell4Value.VerticalAlignment = Element.ALIGN_MIDDLE;
                pCell1Value.MinimumHeight = 30;
                pCell2Value.MinimumHeight = 30;
                pCell3Value.MinimumHeight = 30;
                pCell4Value.MinimumHeight = 30;
                tSV.AddCell(pCell1Value);
                tSV.AddCell(pCell2Value);
                tSV.AddCell(pCell3Value);
                tSV.AddCell(pCell4Value);
            }

            para.Alignment = Element.ALIGN_CENTER;
            document.Add(para);
            document.Add(paddingSpace);
            PdfPTable t = new PdfPTable(2);
            t.TotalWidth = 520;
            float[] widths = new float[] { 100, 420 };
            t.SetWidths(widths);
            t.LockedWidth = true;
            t.PaddingTop = 100;
            t.DefaultCell.MinimumHeight = 30;
            t.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            //t.AddCell("Mã hóa đơn: ");
            //t.AddCell(hoaDon.maHD.ToString());
            PdfPCell pc1 = new PdfPCell(new Phrase("Mã hóa đơn: ", fontNormal));
            pc1.MinimumHeight = 30;
            pc1.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell pc2 = new PdfPCell(new Phrase(hoaDon.maHD.ToString(), fontNormal));
            pc2.MinimumHeight = 30;
            pc2.VerticalAlignment = Element.ALIGN_MIDDLE;
            t.AddCell(pc1);
            t.AddCell(pc2);

            //t.AddCell("Phòng: ");
            //t.AddCell(pt.FirstOrDefault().tblPhongTro.tenPhong.ToString() +"("+ pt.FirstOrDefault().maPhong.ToString()+ ")");
            PdfPCell pc3 = new PdfPCell(new Phrase("Phòng: ", fontNormal));
            pc3.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc3.MinimumHeight = 30;
            PdfPCell pc4 = new PdfPCell(new Phrase(pt.FirstOrDefault().tblPhongTro.tenPhong.ToString() + " (" + pt.FirstOrDefault().maPhong.ToString() + ")", fontNormal));
            pc4.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc4.MinimumHeight = 30;
            t.AddCell(pc3);
            t.AddCell(pc4);

            //t.AddCell("Ngày lập hóa đơn: ");
            //t.AddCell(hoaDon.ngayLap.Value.ToString("dd/MM/yyyy"));
            PdfPCell pc5 = new PdfPCell(new Phrase("Ngày lập hóa đơn: ", fontNormal));
            pc5.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc5.MinimumHeight = 30;
            PdfPCell pc6 = new PdfPCell(new Phrase(hoaDon.ngayLap.Value.ToString("dd/MM/yyyy"), fontNormal));
            pc6.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc6.MinimumHeight = 30;
            t.AddCell(pc5);
            t.AddCell(pc6);

            //t.AddCell("Lập hóa đơn cho tháng: ");
            //t.AddCell(hoaDon.ngayCanLap.Value.ToString("MM"));
            PdfPCell pc7 = new PdfPCell(new Phrase("Lập hóa đơn cho tháng: ", fontNormal));
            pc7.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc7.MinimumHeight = 30;
            PdfPCell pc8 = new PdfPCell(new Phrase(hoaDon.ngayCanLap.Value.ToString("MM"), fontNormal));
            pc8.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc8.MinimumHeight = 30;
            t.AddCell(pc7);
            t.AddCell(pc8);

            //t.AddCell("Thông tin SV: ");
            //t.AddCell(tSV);
            PdfPCell pc9 = new PdfPCell(new Phrase("Thông tin SV: ", fontNormal));
            pc9.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc9.MinimumHeight = 30;
            t.AddCell(pc9);
            t.AddCell(tSV);

            //Start chi phí
            //t.AddCell("Tiền điện: ");
            //t.AddCell(string.Format("{0:0,0 VNĐ}", cthoaDon.tienDien.Value));
            PdfPCell pc11 = new PdfPCell(new Phrase("Tiền điện: ", fontNormal));
            pc11.MinimumHeight = 30;
            pc11.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell pc12 = new PdfPCell(new Phrase(string.Format("{0:0,0 VNĐ}", cthoaDon.tienDien.Value), fontNormal));
            pc12.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc12.MinimumHeight = 30;
            t.AddCell(new PdfPCell(new Phrase("Tiền điện: ", fontNormal)));
            t.AddCell(pc12);

            //t.AddCell("Tiền nước: ");
            //t.AddCell(string.Format("{0:0,0 VNĐ}", cthoaDon.tienNuoc.Value));
            PdfPCell pc13 = new PdfPCell(new Phrase("Tiền nước: ", fontNormal));
            pc13.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc13.MinimumHeight = 30;
            PdfPCell pc14 = new PdfPCell(new Phrase(string.Format("{0:0,0 VNĐ}", cthoaDon.tienNuoc.Value), fontNormal));
            pc14.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc14.MinimumHeight = 30;
            t.AddCell(pc13);
            t.AddCell(pc14);

            //t.AddCell("Tiền Wifi: ");
            //t.AddCell(string.Format("{0:0,0 VNĐ}", cthoaDon.tienWifi.Value));
            PdfPCell pc15 = new PdfPCell(new Phrase("Tiền Wifi: ", fontNormal));
            pc15.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc15.MinimumHeight = 30;
            PdfPCell pc16 = new PdfPCell(new Phrase(string.Format("{0:0,0 VNĐ}", cthoaDon.tienWifi.Value), fontNormal));
            pc16.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc16.MinimumHeight = 30;
            t.AddCell(pc15);
            t.AddCell(pc16);

            //t.AddCell("Tiền gửi xe: ");
            //t.AddCell(string.Format("{0:0,0 VNĐ}", cthoaDon.tienGuiXe.Value));
            PdfPCell pc17 = new PdfPCell(new Phrase("Tiền gửi xe: ", fontNormal));
            pc17.MinimumHeight = 30;
            pc17.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell pc18 = new PdfPCell(new Phrase(string.Format("{0:0,0 VNĐ}", cthoaDon.tienGuiXe.Value), fontNormal));
            pc18.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc18.MinimumHeight = 30;
            t.AddCell(pc17);
            t.AddCell(pc18);

            //t.AddCell("Phụ phí: ");
            //t.AddCell(string.Format("{0:0,0 VNĐ}", cthoaDon.phuPhi.Value));
            PdfPCell pc19 = new PdfPCell(new Phrase("Phụ phí: ", fontNormal));
            pc19.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc19.MinimumHeight = 30;
            PdfPCell pc20 = new PdfPCell(new Phrase(string.Format("{0:0,0 VNĐ}", cthoaDon.phuPhi.Value), fontNormal));
            pc20.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc20.MinimumHeight = 30;
            t.AddCell(pc19);
            t.AddCell(pc20);

            //t.AddCell("Tiền phòng: ");
            //t.AddCell(string.Format("{0:0,0 VNĐ}", cthoaDon.TienPhong));
            PdfPCell pc21 = new PdfPCell(new Phrase("Tiền phòng: ", fontNormal));
            pc21.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc21.MinimumHeight = 30;
            PdfPCell pc22 = new PdfPCell(new Phrase(string.Format("{0:0,0 VNĐ}", cthoaDon.TienPhong), fontNormal));
            pc22.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc22.MinimumHeight = 30;
            t.AddCell(pc21);
            t.AddCell(pc22);

            //t.AddCell("Tổng tiền: ");
            //PdfPCell cell = new PdfPCell(new Phrase(string.Format("{0:0,0 VNĐ}", (cthoaDon.TienPhong + cthoaDon.tienDien.Value + cthoaDon.tienNuoc.Value + cthoaDon.tienWifi.Value + cthoaDon.tienGuiXe.Value + cthoaDon.phuPhi.Value + cthoaDon.TienPhong))));
            //cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);
            //t.AddCell(cell);

            iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);

            PdfPCell pc23 = new PdfPCell(new Phrase("Tổng tiền: ", fontBold));
            pc23.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc23.MinimumHeight = 30;
            PdfPCell pc24 = new PdfPCell(new Phrase(string.Format("{0:0,0 VNĐ}", (cthoaDon.TienPhong + cthoaDon.tienDien.Value + cthoaDon.tienNuoc.Value + cthoaDon.tienWifi.Value + cthoaDon.tienGuiXe.Value + cthoaDon.phuPhi.Value)), fontBold));
            pc24.VerticalAlignment = Element.ALIGN_MIDDLE;
            pc24.MinimumHeight = 30;
            t.AddCell(pc23);
            t.AddCell(pc24);
            //end chi phí


            //Add the table to our document
            document.Add(t);
            document.Close();

        }
        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtTienDien.Text.Trim().Length == 0 || txtTienGiuXe.Text.Trim().Length == 0 || txtTienNuoc.Text.Trim().Length == 0 || txtPhuPhi.Text.Trim().Length == 0 || txtTienWifi.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hóa đơn", "Thông báo");
            else if ((dtgThangCanLap.Value - hdSauCung).TotalDays > 32)
                MessageBox.Show("Tháng trước bạn vẫn chưa lập hóa đơn!\n Không thể lập hóa đơn cho tháng tiếp theo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                DialogResult HoiXN = MessageBox.Show("Bạn có chắc chắn muốn lập hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (HoiXN == DialogResult.Yes)
                {
                    tblHoaDon hd = TaoHoaDon();
                    clshd.TaoHoaDon(hd);
                    tblCT_HoaDon cthd = TaoCTHoaDon(hd.maHD);
                    clsCTHD.TaoChiTietHoaDon(cthd);
                    MessageBox.Show("Tạo hóa đơn thành công", "Thông báo");
                    this.DialogResult = DialogResult.OK;

                    GenerateHDPDF(hd, cthd);
                }
            }
        }

        private void TxtTienDien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtTienNuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtTienWifi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtTienGiuXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void TxtPhuPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }
    }
}
