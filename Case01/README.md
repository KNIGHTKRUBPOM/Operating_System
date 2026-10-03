# 📊 Case Study 01: Multithreaded Processing & Performance Benchmarking

การประมวลผลข้อมูลขนาดใหญ่แบบคู่ขนาน (Parallel Processing) ด้วย Multithreading และการวัดประสิทธิภาพเวลาทำงาน

---

## 📖 ภาพรวมของโจทย์ (Overview)

ในโจทย์นี้ โปรแกรมจะทำการอ่านข้อมูลตัวเลขทศนิยม (`float`) จำนวน **11,000,001 ค่า** จากไฟล์ไบนารี `data.bin` เข้าสู่หน่วยความจำในรูปแบบ `decimal[]` โดยคูณด้วยสเกลแฟกเตอร์ 36

จากนั้น โปรแกรมจะสร้างเธรดทำงานคู่ขนาน 2 เธรด (`Th1` และ `Th2`) เพื่อประมวลผลอัลกอริทึมการคำนวณผ่านฟังก์ชันใน `CalculatingFunctions.dll` (`CalClass.Calculate1`) และวัดเวลาการทำงานทั้งหมดด้วย `System.Diagnostics.Stopwatch`

---

## 🗂 โครงสร้างโปรเจกต์

```text
Case01/
├── CaseStudy01/
│   ├── CaseStudy01.sln           # Visual Studio Solution
│   ├── CaseStudy01.csproj        # .NET 9 C# Project Configuration
│   ├── Program.cs                # โค้ดหลักในการโหลดข้อมูลและรันเธรด
│   ├── data.bin                  # ไฟล์ข้อมูลไบนารีขนาด ~44 MB (11M records)
│   └── DLL/
│       └── CalculatingFunctions.dll # Library อัลกอริทึมคำนวณ CalClass
└── README.md
```

---

## ⚙️ คอนเซปต์ของระบบปฏิบัติการ (OS Concepts)

1. **Multithreading & Concurrency**:
   - การแบ่งงานประมวลผลให้หลายเธรดทำงานพร้อมกันบน Multi-core CPU
   - ใช้ `Thread.Start()` เพื่อเริ่มการทำงาน และ `Thread.Join()` เพื่อรอให้ทั้งสองเธรดคำนวณเสร็จสมบูรณ์ก่อนสรุปผล
2. **Binary I/O Performance**:
   - การอ่านไฟล์แบบไบนารีระดับต่ำ (`FileStream` + `BinaryReader`) เพื่อความเร็วสูงสุดในการโหลดข้อมูลขนาด 44MB เข้าสู่ RAM
3. **Execution Profiling**:
   - การจับเวลาการทำงานระดับมิลลิวินาทีด้วยคลาสความละเอียดสูง `Stopwatch`

---

## 🚀 วิธีการรันโปรเจกต์

```bash
# นำทางไปยังโฟลเดอร์โปรเจกต์
cd Case01/CaseStudy01

# บิลด์โปรเจกต์
dotnet build

# รันโปรแกรม
dotnet run
```
