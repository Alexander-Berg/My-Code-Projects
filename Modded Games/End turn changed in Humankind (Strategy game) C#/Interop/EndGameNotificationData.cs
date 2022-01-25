// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EndGameNotificationData
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  [NotificationPriority(NotificationPriority = NotificationPriority.High)]
  public struct EndGameNotificationData : INotificationData, ISerializable
  {
    public EndGameConditionType EndGameCause;

    public EndGameNotificationData(EndGameConditionType endGameCause) => this.EndGameCause = endGameCause;

    public void Serialize(Serializer serializer) => this.EndGameCause = (EndGameConditionType) serializer.SerializeElement("EndGameCause", (int) this.EndGameCause);
  }
}
