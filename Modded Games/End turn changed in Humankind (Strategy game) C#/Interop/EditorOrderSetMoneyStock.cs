// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderSetMoneyStock
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderSetMoneyStock : EditorOrder
  {
    public int EmpireIndex = -1;
    public int MoneyStock;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderSetMoneyStock;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.EmpireIndex);
      writer.Write(this.MoneyStock);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.EmpireIndex = reader.ReadInt32();
      this.MoneyStock = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.EmpireIndex = serializer.SerializeElement("EmpireIndex", this.EmpireIndex);
      this.MoneyStock = serializer.SerializeElement("MoneyStock", this.MoneyStock);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.EmpireIndex);
  }
}
