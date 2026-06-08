namespace EmergencySystem.Domain.Enums;

public enum ResponderStatus
{
    Available = 1,       // متاح لاستقبال بلاغات
    Assigned = 2,        // تم إسناد بلاغ له وينتظر القبول
    EnRoute = 3,         // في الطريق للحادث
    OnScene = 4,         // وصل إلى موقع الحادث
    Busy = 5,            // مشغول بحادث
    Offline = 6,         // غير متصل بالنظام
    OnBreak = 7,         // في استراحة
    Unavailable = 8      // غير متاح مؤقتاً
}
