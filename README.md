# 🖥️ Operating Systems (OS) - Lab & Case Studies

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/Language-C%23-239120?logo=csharp&logoColor=white)](https://docs.microsoft.com/dotnet/csharp/)
[![Topic](https://img.shields.io/badge/Course-Operating%20Systems-orange?logo=linux&logoColor=white)](#)
[![Status](https://img.shields.io/badge/Status-Completed-brightgreen)](#)

คลังโค้ดแบบฝึกหัดและกรณีศึกษา (Lab Exercises & Case Studies) สำหรับวิชา **Operating Systems (Year 2)** เน้นหัวข้อ **Multithreading, Concurrency, Critical Sections, Thread Synchronization** และการแก้ปัญหาคลาสสิกอย่าง **Producer-Consumer Problem (Bounded Buffer)** ด้วยภาษา C# (.NET 9)

---

## 📑 สารบัญ (Table of Contents)

- [🗂 โครงสร้างโปรเจกต์ (Project Structure)](#-โครงสร้างโปรเจกต์-project-structure)
- [📚 รายละเอียดเนื้อหาในคลังโค้ด](#-รายละเอียดเนื้อหาในคลังโค้ด)
  - [1. Exercises (Multithreading Basics)](#1-exercises-multithreading-basics)
  - [2. Case Study 01 (Parallel Computation & Benchmarking)](#2-case-study-01-parallel-computation--benchmarking)
  - [3. Case Study 02 (Producer-Consumer & Monitor Synchronization)](#3-case-study-02-producer-consumer--monitor-synchronization)
- [🧠 คอนเซปต์สำคัญของระบบปฏิบัติการ (Core OS Concepts)](#-คอนเซปต์สำคัญของระบบปฏิบัติการ-core-os-concepts)
- [🛠 ความต้องการของระบบ (Prerequisites)](#-ความต้องการของระบบ-prerequisites)
- [🚀 วิธีการใช้งานและการรันโปรเจกต์ (Getting Started)](#-วิธีการใช้งานและการรันโปรเจกต์-getting-started)

---

## 🗂 โครงสร้างโปรเจกต์ (Project Structure)

```text
.
├── Exercises/                       # แบบฝึกหัดพื้นฐาน C# Multithreading
│   ├── Program1.cs                  # Thread creation & concurrent execution
│   ├── Program2.cs                  # Shared resource access
│   ├── Program3.cs                  # Thread pausing (Thread.Sleep)
│   ├── Program4.cs                  # Thread waiting (Thread.Join)
│   └── README.md                    # เอกสารอธิบายแบบฝึกหัด
│
├── Case01/                          # กรณีศึกษาที่ 1: Multithreaded Processing
│   ├── README.md                    # รายละเอียดและวิธีรัน Case Study 01
│   └── CaseStudy01/
│       ├── CaseStudy01.sln          # Solution file
│       ├── CaseStudy01.csproj       # Project configuration (.NET 9)
│       ├── Program.cs               # โค้ดประมวลผลข้อมูลคู่ขนาน
│       ├── data.bin                 # ชุดข้อมูลไบนารี (11 ล้านข้อมูล)
│       └── DLL/
│           └── CalculatingFunctions.dll # Library ฟังก์ชันคำนวณ CalClass
│
├── Case02/                          # กรณีศึกษาที่ 2: Producer-Consumer Problem
│   ├── README.md                    # รายละเอียดและตารางเปรียบเทียบก่อน-หลังแก้
│   ├── CaseStudy02.pdf              # เอกสารโจทย์อย่างเป็นทางการ
│   ├── Main_Program.cs              # โจทย์เริ่มต้น (เกิด Race Condition / Unsafe)
│   └── Case02/
│       ├── case02.sln               # Solution file
│       ├── case02.csproj            # Project configuration (.NET 9)
│       └── Program.cs               # โค้ดที่แก้สมบูรณ์ (Thread-Safe Buffer)
│
├── .gitignore                       # ละเว้นไฟล์ build artifacts, cache และ archives
└── README.md                        # เอกสารภาพรวมหลักของโปรเจกต์
```

---

## 📚 รายละเอียดเนื้อหาในคลังโค้ด

### 1. [Exercises/](./Exercises/) (Multithreading Basics)
รวบรวมพื้นฐานสำคัญของการจัดการเธรดในระบบปฏิบัติการ:
- **`Program1.cs`**: การสร้างและการสั่งทำงานเธรด (`Thread.Start`) สังเกตการทำงานสลับกันของแต่ละเธรด (Interleaving) ตามการจัดสรร CPU
- **`Program2.cs`**: การเข้าถึงตัวแปรส่วนกลาง (`shared memory`) แสดงให้เห็นถึงการทำงานร่วมกันของเธรด
- **`Program3.cs`**: การพักการทำงานของเธรดชั่วคราว (`Thread.Sleep`) เพื่อควบคุมจังหวะการทำงาน
- **`Program4.cs`**: การประสานการทำงานและรอเธรดลูก (`Thread.Join`) ก่อนที่เธรดหลักจะดำเนินงานต่อไป

### 2. [Case01/](./Case01/) (Parallel Computation & Benchmarking)
- **โจทย์:** อ่านข้อมูลขนาดใหญ่จาก `data.bin` (จำนวน 11,000,001 ค่า) เข้าหน่วยความจำ และใช้ Multi-threading (2 Threads) ในการประมวลผลข้อมูลผ่าน Dynamic Link Library (`CalculatingFunctions.dll`)
- **การวัดผล:** วัดเวลาการคำนวณด้วย `System.Diagnostics.Stopwatch` และแสดงค่าผลลัพธ์ที่มีความละเอียดสูง (`F25`)

### 3. [Case02/](./Case02/) (Producer-Consumer & Monitor Synchronization)
- **โจทย์:** จำลองระบบ Bounded Circular Buffer (ความจุ 10 ช่อง) ที่มี Producers 2 เธรด (ผลิตรวม 102 ค่า) และ Consumers 3 เธรด (ดึงข้อมูลรวม 102 ค่า)
- **การแก้ปัญหา:** 
  - ใช้ `lock` เพื่อรับประกัน **Mutual Exclusion** ในการเข้าถึง Buffer
  - ใช้ `Monitor.Wait()` เพื่อหยุดรอเมื่อ Buffer เต็ม (สำหรับ Producer) หรือเมื่อ Buffer ว่าง (สำหรับ Consumer)
  - ใช้ `Monitor.PulseAll()` เพื่อส่งสัญญาณปลุกเธรดที่กำลังรอ
  - ใช้ `Thread.Join()` ใน Main Thread เพื่อรอให้ทุกเธรดเสร็จสิ้นอย่างสมบูรณ์ ป้องกันโปรแกรมปิดก่อนกำหนด

---

## 🧠 คอนเซปต์สำคัญของระบบปฏิบัติการ (Core OS Concepts)

1. **Concurrency vs Parallelism**: การทำความเข้าใจว่าเธรดสามารถทำงานสลับกัน (Context Switching) หรือทำงานบนคอร์แยกกันจริง (Multi-core)
2. **Race Condition**: ภาวะที่ผลลัพธ์ของการประมวลผลขึ้นอยู่กับลำดับการทำงานที่ไม่สามารถคาดเดาได้ของเธรด
3. **Critical Section**: ช่วงโค้ดที่มีการเข้าถึงทรัพยากรส่วนกลาง ต้องมีการป้องกันให้มีเพียงเธรดเดียวทำงานในเวลาใดเวลาหนึ่ง
4. **Synchronization Primitives**: การใช้ `Monitor`, `Mutex`, หรือ `Semaphore` เพื่อจัดลำดับการทำงานและส่งสัญญาณระหว่างเธรด
5. **Deadlock & Starvation Prevention**: การออกแบบเงื่อนไขรอรับสัญญาณที่ปลอดภัย เพื่อป้องกันการค้างตลอดกาล

---

## 🛠 ความต้องการของระบบ (Prerequisites)

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) หรือใหม่กว่า
- Visual Studio 2022 (v17.12+) หรือ Visual Studio Code (พร้อมส่วนขยาย C# Dev Kit)
- Git สำหรับการจัดการ Source Code

---

## 🚀 วิธีการใช้งานและการรันโปรเจกต์ (Getting Started)

### โคลนโปรเจกต์ (Clone Repository)
```bash
git clone https://github.com/KNIGHTKRUBPOM/Operating_System.git
cd Operating_System
```

### การรัน Case Study 01
```bash
cd Case01/CaseStudy01
dotnet restore
dotnet build
dotnet run
```

### การรัน Case Study 02
```bash
cd Case02/Case02
dotnet restore
dotnet build
dotnet run
```

---

## 👨‍💻 ผู้จัดทำ (Author)
- **Athichanan** ([@KNIGHTKRUBPOM](https://github.com/KNIGHTKRUBPOM))
- ผลงานและแบบฝึกหัดวิชา **Operating Systems** (Year 2)

