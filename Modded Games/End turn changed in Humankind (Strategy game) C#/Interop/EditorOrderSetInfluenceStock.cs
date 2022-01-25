// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderSetInfluenceStock
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderSetInfluenceStock : EditorOrder
  {
    public int EmpireIndex = -1;
    public int InfluenceStock;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderSetInfluenceStock;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.EmpireIndex);
      writer.Write(this.InfluenceStock);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.EmpireIndex = reader.ReadInt32();
      this.InfluenceStock = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.EmpireIndex = serializer.SerializeElement("EmpireIndex", this.EmpireIndex);
      this.InfluenceStock = serializer.SerializeElement("InfluenceStock", this.InfluenceStock);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.EmpireIndex);
  }
}
