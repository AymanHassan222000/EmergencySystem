namespace EmergencySystem.Domain.Enums;

public enum IncidentStatus
{
    Pending = 1,        // تم إنشاء البلاغ
    Assigned = 2,       // تم تعيين مستجيب
    Accepted = 3,       // المستجيب قبل المهمة
    EnRoute = 4,        // في الطريق
    Arrived = 5,        // وصل للموقع
    InProgress = 6,     // جاري التعامل مع الحادث
    Resolved = 7,       // تم حل المشكلة
    Closed = 8,         // أُغلق البلاغ
    Cancelled = 9       // تم إلغاؤه
}
