using System;
using System.Collections.Generic;
using System.Linq;
abstract class DataInduk
{
    public abstract string Kode { get; set; }
    public abstract string NamaLengkap { get; set; }
    public abstract string ProgramStudi { get; set; }

    public abstract void TampilkanData();
}
class DataMahasiswa : DataInduk
{
    private string kode;
    private string nama;
    private string prodi;

    public override string Kode
    {
        get { return kode; }
        set { kode = value; }
    }

    public override string NamaLengkap
    {
        get { return nama; }
        set { nama = value; }
    }

    public override string ProgramStudi
    {
        get { return prodi; }
        set { prodi = value; }
    }

    public override void TampilkanData()
    {
        Console.WriteLine($"NIM: {Kode}, Nama: {NamaLengkap}, Prodi: {ProgramStudi}");
    }
}

class SistemKampus
{
    static List<DataMahasiswa> koleksiMahasiswa = new List<DataMahasiswa>();

    static void Main(string[] args)
    {
        bool jalan = true;
        while (jalan)
        {
            Console.WriteLine("\n=== Sistem Akademik ===");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Lihat Mahasiswa");
            Console.WriteLine("3. Update Mahasiswa");
            Console.WriteLine("4. Hapus Mahasiswa");
            Console.WriteLine("5. Keluar");
            Console.Write("Masukkan pilihan (1-5): ");
            string opsi = Console.ReadLine();

            switch (opsi)
            {
                case "1":
                    InputData();
                    break;
                case "2":
                    LihatData();
                    break;
                case "3":
                    EditData();
                    break;
                case "4":
                    HapusData();
                    break;
                case "5":
                    jalan = false;
                    Console.WriteLine("Program selesai.");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak tersedia.");
                    break;
            }
        }
    }

    static void InputData()
    {
        Console.Write("Masukkan NIM: ");
        string inputKode = Console.ReadLine();

        if (koleksiMahasiswa.Any(x => x.Kode == inputKode))
        {
            Console.WriteLine("NIM tersebut sudah digunakan.");
            return;
        }

        Console.Write("Masukkan Nama: ");
        string inputNama = Console.ReadLine();

        Console.Write("Masukkan Prodi: ");
        string inputProdi = Console.ReadLine();

        DataMahasiswa entriBaru = new DataMahasiswa
        {
            Kode = inputKode,
            NamaLengkap = inputNama,
            ProgramStudi = inputProdi
        };

        koleksiMahasiswa.Add(entriBaru);
        Console.WriteLine("Data berhasil ditambahkan.");
    }

    static void LihatData()
    {
        if (koleksiMahasiswa.Count == 0)
        {
            Console.WriteLine("Belum ada data mahasiswa.");
            return;
        }

        Console.WriteLine("\n== Daftar Mahasiswa ==");
        foreach (var item in koleksiMahasiswa)
        {
            item.TampilkanData();
        }
    }

    static void EditData()
    {
        Console.Write("Masukkan NIM yang ingin diubah: ");
        string targetKode = Console.ReadLine();

        var data = koleksiMahasiswa.FirstOrDefault(x => x.Kode == targetKode);
        if (data == null)
        {
            Console.WriteLine("Data tidak ditemukan.");
            return;
        }

        Console.Write("Nama baru: ");
        data.NamaLengkap = Console.ReadLine();

        Console.Write("Prodi baru: ");
        data.ProgramStudi = Console.ReadLine();

        Console.WriteLine("Data berhasil diperbarui.");
    }

    static void HapusData()
    {
        Console.Write("Masukkan NIM yang ingin dihapus: ");
        string kodeHapus = Console.ReadLine();

        var data = koleksiMahasiswa.FirstOrDefault(x => x.Kode == kodeHapus);
        if (data == null)
        {
            Console.WriteLine("Data tidak ditemukan.");
            return;
        }

        koleksiMahasiswa.Remove(data);
        Console.WriteLine("Data berhasil dihapus.");
    }
}