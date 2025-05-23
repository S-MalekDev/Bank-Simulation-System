# Bank Simulation System



## 🛠️ كيفية التثبيت والتشغيل (Installation & Run)

1. **قم بتحميل المشروع:**
   - من GitHub: [Download ZIP] أو `git clone`

2. **استيراد قاعدة البيانات:**
   - إذا كنت ترغب في استخدام السكربت، افتح SQL Server Management Studio.
   - نفّذ ملف `script.sql` داخل قاعدة بيانات جديدة.
   - إذا كنت تفضل استخدام النسخة الاحتياطية، قم باستعادة قاعدة البيانات باستخدام ملف `BANK.bak` من خلال SQL Server.

3. **تعديل الاتصال بقاعدة البيانات:**
   - افتح ملف `App.config` أو `Settings.cs`
   - غيّر بيانات الاتصال (`ConnectionString`) لتناسب جهازك (اسم السيرفر واسم قاعدة البيانات).

4. **تشغيل البرنامج:**
   - افتح الحل (Solution) في Visual Studio.
   - اضغط `Start` لتشغيل البرنامج.

## نظرة عامة
مشروع **Bank Simulation System** هو محاكاة لنظام بنك يوفر مجموعة شاملة من العمليات البنكية، تشمل إدارة الأشخاص، المستخدمين، الحسابات، العملاء، السحب والإيداع، التحويلات، بالإضافة إلى تتبع تاريخ المعاملات. يهدف المشروع إلى توفير بيئة عمل شبيهة بالبنوك الحقيقية تسهل فهم وتطبيق المفاهيم البرمجية وإدارة قواعد البيانات.

1. الميزات الرئيسية
- إدارة الأشخاص: إضافة، تعديل، حذف، وعرض معلومات الأفراد.
- إدارة المستخدمين: إضافة، تعديل، حذف، تغيير كلمة السر، وتحديد صلاحيات كل مستخدم بدقة.
- إدارة الحسابات والعملاء: فتح حسابات جديدة، تعديل بيانات العملاء، عرض معلومات العميل، كشف حساب.
- عمليات مالية: السحب، الإيداع، التحويلات الداخلية والخارجية.
- إدارة الخدمات وتحديد أسعارها.
- تتبع تاريخ العميل: عرض جميع العمليات السابقة من إيداعات وسحوبات وتحويلات.

2. التقنيات المستخدمة
- لغة البرمجة: C#
- واجهة المستخدم: Windows Forms
- قاعدة البيانات: SQL Server
- تقنية الوصول للبيانات: ADO.NET
- تصميم النظام: 3-Layer Architecture 

3. الحماية والأمان
- تشفير كلمات المرور باستخدام Hashing.
- الحماية من هجمات الحقن SQL Injection باستخدام استعلامات معلماتية (Parameterized Queries).
- نظام صلاحيات دقيق يحد من وصول المستخدمين بناءً على دورهم.
- لا يتضمن المشروع تسجيل محاولات الدخول الفاشلة (Logging).

4. رخصة الاستخدام
هذا المشروع للاستخدام الشخصي والتعلم فقط.

## 💡 ملاحظات مهمة (Important Notes)

- عند أول تشغيل تحتاج إلى تشغيل البرنامج كمسؤول و إضافة معلومات المستخدم وكلمة المرور يدويًا 
- إذا لم تكن موجودة، سيظهر خطأ عند التشغيل.
- لتفادي ذلك، تأكد من إضافة اسم المستخدم وكلمة المرور التالية:

- لتسجيل الدخول باستخدام المعلومات الافتراضية:
  - **Username:** `admin`
  - **Password:** `admin`



---

## 🤝 المساهمة (Contribution)

مرحبًا بأي اقتراحات أو تحسينات، لا تتردد في فتح Pull Request.


