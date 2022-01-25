// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderResetMerchantAffinityGauge
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderResetMerchantAffinityGauge : EditorOrder
  {
    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderResetMerchantAffinityGauge;

    public override void Serialize(Serializer serializer)
    {
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
