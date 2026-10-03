# 🧵 Multithreading Lab Exercises

รวมแบบฝึกหัดพื้นฐานการเขียนโปรแกรมแบบมัลติเธรด (Multithreading) ด้วยภาษา C# บน .NET สำหรับวิชา Operating Systems

---

## 📋 สารบัญแบบฝึกหัด

| ไฟล์ | หัวข้อ | คำอธิบาย | จุดสังเกต / คอนเซปต์ OS |
| :--- | :--- | :--- | :--- |
| [`Program1.cs`](./Program1.cs) | **Simple Threading** | การสร้างและสั่งทำงาน 2 เธรดพร้อมกัน (`th1`, `th2`) | **Concurrency & Interleaving**: ผลลัพธ์ใน Console จะสลับกันไปมาระหว่าง Thread 1 และ Thread 2 ตามการจัดสรร CPU ของ OS Scheduler |
| [`Program2.cs`](./Program2.cs) | **Resource Sharing** | การเข้าถึงตัวแปรส่วนกลาง (`static int resource`) พร้อมกัน | **Shared Memory**: การเข้าถึงตัวแปรเดียวกันโดยไม่มี Synchronization |
| [`Program3.cs`](./Program3.cs) | **Thread Sleep** | การใช้ `Thread.Sleep(1000)` เพื่อหน่วงเวลาการทำงาน | **Thread States & Yielding**: การให้ Main Thread พักการทำงานเพื่อให้ Worker Thread ทำงานเสร็จก่อน |
| [`Program4.cs`](./Program4.cs) | **Thread Join** | การใช้ `th1.Join()` เพื่อรอให้ Worker Thread ทำงานเสร็จสิ้น | **Thread Synchronization**: บังคับให้ Main Thread รอจนกระทั่ง Worker Thread จบการทำงานอย่างสมบูรณ์ |

---

## 🚀 วิธีการคอมไพล์และรัน

คุณสามารถรันไฟล์เดี่ยวเหล่านี้ผ่าน .NET SDK หรือ C# compiler:

```bash
# คอมไพล์ด้วย csc (C# Compiler)
csc Program1.cs
.\Program1.exe

# หรือสร้างโปรเจกต์คอนโซลชั่วคราว
dotnet new console -o temp_run
copy Program1.cs temp_run\Program.cs
cd temp_run
dotnet run
```
