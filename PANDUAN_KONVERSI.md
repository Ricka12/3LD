# Panduan Konversi ke PowerPoint (.pptx)

File utama presentasi: `/tmp/workspace/Ricka12/3LD/Presentasi_Chain_of_Custody.md`

## Opsi 1 — Pandoc (rekomendasi cepat)

### 1) Instal Pandoc
- Ubuntu/Debian:
  ```bash
  sudo apt update && sudo apt install -y pandoc
  ```

### 2) Konversi ke PPTX
Dari root repository:
```bash
cd /tmp/workspace/Ricka12/3LD
pandoc Presentasi_Chain_of_Custody.md -t pptx -o Presentasi_Chain_of_Custody.pptx
```

### 3) Cek hasil
Buka `Presentasi_Chain_of_Custody.pptx` di Microsoft PowerPoint/LibreOffice, lalu sesuaikan tema visual bila diperlukan.

---

## Opsi 2 — Marp CLI

### 1) Instal Marp CLI
```bash
npm install -g @marp-team/marp-cli
```

### 2) Export langsung ke PPTX
```bash
cd /tmp/workspace/Ricka12/3LD
marp Presentasi_Chain_of_Custody.md --pptx -o Presentasi_Chain_of_Custody.pptx
```

### 3) Kustomisasi
Jika ingin tema khusus, tambah CSS/theme Marp lalu export ulang.

---

## Opsi 3 — Manual (PowerPoint/Google Slides)

1. Buka `Presentasi_Chain_of_Custody.md`.  
2. Gunakan pemisah `---` sebagai batas antar slide.  
3. Copy konten tiap slide ke template PPT.  
4. Tambahkan gambar dari folder `assets/`.  
5. Simpan sebagai `.pptx`.

---

## Tips agar hasil konversi rapi

- Gunakan font standar (Calibri/Arial).
- Maksimal 5–7 bullet per slide.
- Gunakan kontras tinggi (teks gelap di latar terang).
- Pastikan URL referensi masih aktif sebelum submit.
- Latihan presentasi dengan file final (`.pptx`) untuk cek animasi/perpindahan.
