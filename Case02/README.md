# 🔄 Case Study 02: Producer-Consumer Problem (Thread-Safe Bounded Buffer)

การแก้ปัญหาคลาสสิกของระบบปฏิบัติการ: **Producer-Consumer Problem** (Bounded Buffer) โดยใช้ **Monitor Synchronization** ในภาษา C#

---

## 📖 รายละเอียดโจทย์ (Problem Description)

โปรแกรมจำลองระบบคิวจำกัดขนาด (Bounded Circular Buffer ขนาด 10 ช่อง) โดยมี:
- **Producers (2 เธรด):**
  - `t1` (ID: 100): ผลิตข้อมูลตัวเลข 0 ถึง 50 (รวม 51 ค่า, หน่วงเวลา 5 ms)
  - `t11` (ID: 200): ผลิตข้อมูลตัวเลข 100 ถึง 150 (รวม 51 ค่า, หน่วงเวลา 7 ms)
  - *รวมข้อมูลที่ผลิตทั้งหมด: 102 ค่า*
- **Consumers (3 เธรด):**
  - `t2` (ID: 1): ดึงข้อมูล 34 ค่า (หน่วงเวลา 16 ms)
  - `t21` (ID: 2): ดึงข้อมูล 34 ค่า (หน่วงเวลา 16 ms)
  - `t22` (ID: 3): ดึงข้อมูล 34 ค่า (หน่วงเวลา 16 ms)
  - *รวมข้อมูลที่ดึงทั้งหมด: 102 ค่า*

---

## 🗂 โครงสร้างไฟล์ในโฟลเดอร์

```text
Case02/
├── CaseStudy02.pdf            # เอกสารโจทย์และข้อกำหนดอย่างเป็นทางการ
├── Main_Program.cs            # โค้ดโจทย์เริ่มต้น (ไม่มี Synchronization - เกิด Race Condition & Data Corruption)
├── Case02/
│   ├── case02.sln             # Visual Studio Solution
│   ├── case02.csproj          # .NET 9 C# Project Configuration
│   └── Program.cs             # โค้ดที่แก้ปัญหาแล้ว (Thread-Safe ด้วย Monitor.Wait / Monitor.PulseAll)
└── README.md
```

---

## ⚖️ เปรียบเทียบ: ก่อนแก้ vs หลังแก้

| หัวข้อ | ก่อนแก้ (`Main_Program.cs`) | หลังแก้ (`Case02/Program.cs`) |
| :--- | :--- | :--- |
| **Mutual Exclusion** | ❌ ไม่มี (`lock`) เธรดเข้าถึงคิวพร้อมกันได้ | ✅ ใช้ `lock (_lock)` ป้องกัน Critical Section |
| **Buffer Overflow** | ❌ เมื่อคิวเต็ม (10 ช่อง) Producer จะเขียนทับข้อมูลเก่า | ✅ ใช้ `while (Count == 10) Monitor.Wait(_lock)` รอจนกว่าจะมีที่ว่าง |
| **Buffer Underflow** | ❌ เมื่อคิวว่าง (0 ช่อง) Consumer จะดึงข้อมูลขยะ | ✅ ใช้ `while (Count == 0) Monitor.Wait(_lock)` รอจนกว่าจะมีข้อมูล |
| **Thread Notification** | ❌ ไม่มีระบบแจ้งเตือน | ✅ ใช้ `Monitor.PulseAll(_lock)` ปลุกเธรดที่กำลังรออยู่ |
| **Termination Handling** | ❌ Main เธรดจบการทำงานก่อน Worker เธรด | ✅ ใช้ `t.Join()` ครบทุกเธรดเพื่อรอให้งานเสร็จสมบูรณ์ |

---

## 🚀 วิธีการรันโปรเจกต์

```bash
# นำทางไปยังโฟลเดอร์โปรเจกต์
cd Case02/Case02

# บิลด์และรัน
dotnet build
dotnet run
```
