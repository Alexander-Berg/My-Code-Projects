// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EndGameApproachingNotificationData
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  [NotificationPriority(NotificationPriority = NotificationPriority.High)]
  public struct EndGameApproachingNotificationData : INotificationData, ISerializable
  {
    public EndGameConditionType EndGameCause;
    public EndGameApproachingNotificationData.EndGameNotificationType NotificationType;
    public int TurnUntilEnd;
    public int[] EmpireIndexes;

    public void Serialize(Serializer serializer)
    {
      this.EndGameCause = (EndGameConditionType) serializer.SerializeElement("EndGameCause", (int) this.EndGameCause);
      this.NotificationType = (EndGameApproachingNotificationData.EndGameNotificationType) serializer.SerializeElement("NotificationType", (int) this.NotificationType);
      this.TurnUntilEnd = serializer.SerializeElement("TurnUntilEnd", this.TurnUntilEnd);
      this.EmpireIndexes = serializer.SerializeElement("EmpireIndexes", this.EmpireIndexes);
    }

    public enum EndGameNotificationType
    {
      LastNotification,
      FirstNotification,
    }
  }
}
