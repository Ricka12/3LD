---
marp: true
theme: default
paginate: true
size: 16:9
---

# Pengumpulan dan Preservasi Bukti Digital  
## (Chain of Custody)

**Tugas Video Presentasi Digital Forensik**  
Nama: **[Isi Nama Mahasiswa]**  
NPM: **[Isi NPM]**

**Catatan presenter (±30 detik):** Perkenalkan diri, jelaskan bahwa fokus presentasi adalah menjaga bukti digital tetap valid dari awal penyitaan sampai proses hukum.

**Transisi:** “Setelah pembukaan, saya akan jelaskan alur pembahasan.”

---

# Agenda Presentasi

1. Pendahuluan  
2. Konsep Chain of Custody  
3. Prinsip Pengumpulan Bukti Digital  
4. Metode Preservasi Bukti  
5. Tools dan Teknik  
6. Studi Kasus  
7. Tantangan, Best Practices, Kesimpulan, Referensi

**Catatan presenter (±35 detik):** Jelaskan struktur agar audiens punya peta materi. Tekankan bahwa sesi akan ditutup dengan kasus dan praktik terbaik.

**Transisi:** “Kita mulai dari dasar: apa itu bukti digital.”

---

# Pendahuluan: Definisi Bukti Digital

- Bukti digital adalah informasi bernilai pembuktian yang disimpan/ditransmisikan secara elektronik.
- Contoh:
  - File dokumen, email, chat, log server
  - Metadata (timestamp, geolokasi, user activity)
  - Data perangkat (laptop, ponsel, cloud)
- Bukti digital harus:
  - **Relevan**
  - **Autentik**
  - **Dapat diverifikasi**

**Catatan presenter (±40 detik):** Tekankan bahwa bukan hanya “isi file”, tapi juga metadata sering jadi kunci kronologi kejadian.

**Transisi:** “Bukti digital punya karakteristik khusus yang membuat penanganannya berbeda dari bukti fisik.”

---

# Pendahuluan: Karakteristik Bukti Digital

- **Volatile**: data RAM/proses aktif bisa hilang saat perangkat mati
- **Fragile**: salah prosedur dapat merusak bukti
- **Easily altered**: akses biasa saja bisa mengubah timestamp
- **Duplicable**: mudah disalin, sehingga butuh pembuktian keaslian

### Mengapa preservasi penting?
- Menjaga integritas
- Menjaga admissibility (dapat diterima di pengadilan)
- Menghindari sengketa keaslian data

**Catatan presenter (±45 detik):** Beri contoh sederhana: membuka file langsung di perangkat asli bisa mengubah metadata “last accessed”.

**Transisi:** “Untuk mengontrol risiko-risiko ini, digunakan konsep Chain of Custody.”

---

# Chain of Custody: Definisi dan Tujuan

**Definisi:**  
Proses dokumentasi kronologis yang mencatat urutan **pengawasan, kontrol, transfer, analisis, dan disposisi** bukti digital.

**Tujuan utama:**
- Memastikan integritas bukti
- Mencegah kontaminasi/perubahan
- Membuktikan autentisitas di pengadilan

**Catatan presenter (±45 detik):** Tegaskan bahwa Chain of Custody bukan dokumen formalitas, tetapi “jejak audit” yang menentukan kekuatan bukti.

**Transisi:** “Lalu, data apa saja yang wajib dicatat dalam Chain of Custody?”

---

# Komponen Chain of Custody + Standar

## Komponen wajib
1. Siapa yang mengumpulkan  
2. Kapan dan di mana dikumpulkan  
3. Siapa yang memegang bukti  
4. Riwayat transfer kepemilikan  
5. Kondisi dan lokasi penyimpanan

## Standar Internasional
- **ISO/IEC 27037:2012**
- **NIST SP 800-86**
- **RFC 3227**
- **ACPO Good Practice Guide**

**Catatan presenter (±50 detik):** Jelaskan bahwa standar memberi kerangka agar prosedur konsisten dan dapat dipertanggungjawabkan lintas institusi.

**Transisi:** “Berikutnya, kita bahas prinsip saat pengumpulan bukti.”

---

# Prinsip Pengumpulan: Order of Volatility (RFC 3227)

Urutan pengambilan data dari yang paling cepat berubah:
1. Register, cache memory
2. Routing table, ARP cache, process table, kernel statistics
3. RAM
4. Temporary file systems
5. Disk/Hard drive
6. Remote logging and monitoring data
7. Physical configuration, network topology
8. Archival media/backup

**Catatan presenter (±55 detik):** Jelaskan logika urutan: yang paling mudah hilang harus diamankan lebih dulu agar tidak kehilangan bukti penting.

**Transisi:** “Selain urutan teknis, ada prinsip tata kelola yang wajib dipatuhi.”

---

# Prinsip Pengumpulan: ACPO + Do No Harm

## 4 Prinsip ACPO
1. Tidak ada tindakan yang boleh mengubah data asli
2. Akses data asli hanya oleh personel kompeten
3. Audit trail harus dibuat dan dipelihara
4. Penanggung jawab wajib memastikan kepatuhan

## Prinsip inti
- **Do No Harm** → jangan mengubah bukti asli

**Catatan presenter (±45 detik):** Sorot bahwa kompetensi petugas dan dokumentasi audit trail sama pentingnya dengan alat forensik.

**Transisi:** “Setelah dikumpulkan, bukti harus dipreservasi dengan metode yang tepat.”

---

# Metode Preservasi: Imaging vs Cloning

## Imaging
- Salinan **bit-by-bit** seluruh media
- Termasuk slack space, unallocated space, deleted files
- Cocok untuk analisis forensik

## Cloning
- Duplikasi ke media lain untuk operasional/backup
- Biasanya fokus area aktif/terbaca

✅ **Untuk forensik, imaging lebih direkomendasikan**

**Catatan presenter (±45 detik):** Tekankan bahwa nilai forensik imaging lebih tinggi karena mempertahankan artefak tersembunyi yang bisa jadi bukti.

**Transisi:** “Bagaimana membuktikan salinan itu identik dengan bukti asli? Gunakan hash.”

---

# Metode Preservasi: Hash & Verifikasi Integritas

- **MD5 (128-bit):** cepat, tetapi rentan collision
- **SHA-1 (160-bit):** lebih baik dari MD5, namun mulai ditinggalkan
- **SHA-256 (256-bit):** standar modern yang direkomendasikan

## Contoh verifikasi
- Hash sebelum imaging: `SHA-256: A1B2...9F`
- Hash sesudah imaging: `SHA-256: A1B2...9F`
- Jika sama → integritas terjaga

**Catatan presenter (±50 detik):** Jelaskan bahwa hash berfungsi seperti “sidik jari digital” untuk memastikan tidak ada perubahan data.

**Transisi:** “Integritas juga dijaga dengan mencegah penulisan ke media asli.”

---

# Metode Preservasi: Write Blocker & Dokumentasi

## Write Blocker
- **Hardware write blocker**: perangkat fisik antarmuka media
- **Software write blocker**: kontrol akses berbasis sistem
- Fungsi: mencegah write operation ke media asli

## Dokumentasi wajib
- Form Chain of Custody
- Foto/video kondisi bukti
- Log aktivitas investigator
- Hash value sebelum & sesudah proses

**Catatan presenter (±45 detik):** Tegaskan: tanpa dokumentasi lengkap, proses teknis yang bagus tetap bisa diperdebatkan di pengadilan.

**Transisi:** “Sekarang kita lihat tools yang umum dipakai dalam praktik.”

---

# Tools Forensik Digital

- **FTK Imager (Free)**
  - Forensic image, hash verification, preview aman
- **EnCase Forensic**
  - Industry standard, court-accepted, fitur lengkap
- **dd command (Linux)**
  - Bit-by-bit copy via command line
- **Autopsy/Sleuth Kit**
  - Open source, analisis file system, timeline

**Catatan presenter (±45 detik):** Sampaikan bahwa pemilihan tools mengikuti kebutuhan kasus, kompetensi tim, dan kebutuhan legal (court-accepted).

**Transisi:** “Berikutnya, kita lihat contoh kasus ketika Chain of Custody tidak berjalan baik.”

---

# Studi Kasus 1: Dugaan Pelanggaran Chain of Custody

## Kasus Prita Mulyasari (2009) – konteks edukatif
- Isu: autentisitas bukti email diperdebatkan
- Permasalahan yang sering disorot dalam diskusi akademik:
  - Dokumentasi Chain of Custody tidak jelas
  - Prosedur pengumpulan tidak terstandar
  - Hash bukti tidak didokumentasikan secara kuat

## Dampak
- Validitas bukti digital dipertanyakan di persidangan

**Catatan presenter (±55 detik):** Tegaskan bahwa slide ini digunakan sebagai pembelajaran pentingnya prosedur, bukan untuk menilai aspek hukum di luar ruang lingkup presentasi.

**Transisi:** “Sekarang simulasi skenario ideal dengan prosedur yang benar.”

---

# Studi Kasus 2: Simulasi Kebocoran Data Perusahaan

## Skenario
Investigasi dugaan exfiltrasi data oleh internal user.

## Langkah Chain of Custody (1–4)
1. Identifikasi perangkat terindikasi  
2. Dokumentasi awal (foto, serial number, kondisi fisik)  
3. Isolasi perangkat dari jaringan  
4. Imaging menggunakan write blocker

**Catatan presenter (±45 detik):** Jelaskan bahwa empat langkah awal adalah fase pengamanan cepat agar bukti tidak berubah atau hilang.

**Transisi:** “Lanjutan langkah berikut memastikan bukti tetap valid hingga pelaporan.”

---

# Lanjutan Simulasi + Ilustrasi Alur

## Langkah Chain of Custody (5–8)
5. Generate hash MD5 & SHA-256  
6. Simpan media asli di evidence locker + tanda tangan form  
7. Analisis pada salinan (bukan media asli)  
8. Pelaporan temuan dengan referensi log Chain of Custody

## Ilustrasi alur (ringkas)
`Identifikasi → Dokumentasi → Isolasi → Imaging → Hash → Penyimpanan → Analisis Copy → Laporan`

> Detail contoh diagram dan template form ada di folder `assets/`.

**Catatan presenter (±50 detik):** Tekankan konsistensi dokumentasi di setiap perpindahan kendali bukti.

**Transisi:** “Meski prosedur sudah jelas, implementasinya punya tantangan nyata.”

---

# Tantangan dan Best Practices

## Tantangan
- Volume data besar (Big Data)
- Cloud & distributed systems
- Enkripsi
- Anti-forensic techniques
- Perbedaan yurisdiksi hukum

## Best Practices
- Selalu gunakan write blocker
- Dokumentasikan setiap langkah
- Gunakan tools yang court-accepted
- Double verification (dua investigator)
- Training & sertifikasi berkala

**Catatan presenter (±50 detik):** Tekankan keseimbangan antara kecepatan respons insiden dan ketelitian prosedural.

**Transisi:** “Kita simpulkan poin-poin utama presentasi ini.”

---

# Kesimpulan

- Chain of Custody adalah fondasi investigasi forensik digital
- Integritas bukti harus dijaga dari awal sampai akhir
- Dokumentasi adalah kunci pembuktian
- Kepatuhan pada standar internasional sangat penting
- Bukti digital tanpa Chain of Custody yang proper berisiko ditolak di pengadilan

**Catatan presenter (±40 detik):** Ulangi pesan utama: “Bukti yang hebat bisa kehilangan nilai jika proses penjagaannya lemah.”

**Transisi:** “Sebagai penutup akademik, berikut referensi utama yang digunakan.”

---

# Referensi

## Standar & Guidelines
1. ISO/IEC 27037:2012  
2. NIST SP 800-86 (2006)  
3. RFC 3227 (2002)  
4. ACPO Good Practice Guide for Digital Evidence (2012)

## Jurnal/Buku
5. Casey, E. (2011). *Digital Evidence and Computer Crime*.  
6. Kent, K., et al. (2006). *NIST SP 800-86*.  
7. Kohn, M., Eloff, J.H.P., & Olivier, M.S. (2013). *Framework for a digital forensic investigation*.  
8. Yasinsac, A., & Manzano, Y. (2001). *Policies to enhance computer and network forensics*.

## Online Resources
9. SANS DFIR: https://www.sans.org/digital-forensics-incident-response/  
10. NIST CFTT: https://www.nist.gov/itl/ssd/software-quality-group/computer-forensics-tool-testing-program-cftt

**Catatan presenter (±35 detik):** Sampaikan bahwa referensi dipilih dari standar resmi dan sumber ilmiah agar materi dapat dipertanggungjawabkan.

**Transisi:** “Terima kasih, saya buka sesi tanya jawab.”

---

# Q&A

Terima kasih atas perhatiannya 🙏  
**Pertanyaan?**

Kontak: **[email placeholder]**

**Catatan presenter (±25 detik):** Tutup dengan percaya diri, ajak audiens bertanya tentang prosedur teknis atau aspek legal Chain of Custody.
