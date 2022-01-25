// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderSetSettlementImprovement
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderSetSettlementImprovement : EditorOrder
  {
    public int SettlementTileIndex;
    public StaticString SettlementImprovementName;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderSetSettlementImprovement;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.SettlementTileIndex);
      writer.Write(this.SettlementImprovementName.ToString());
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.SettlementTileIndex = reader.ReadInt32();
      this.SettlementImprovementName = new StaticString(reader.ReadString());
    }

    public override void Serialize(Serializer serializer)
    {
      this.SettlementTileIndex = serializer.SerializeElement("SettlementTileIndex", this.SettlementTileIndex);
      this.SettlementImprovementName = serializer.SerializeElement<StaticString>("SettlementImprovementName", this.SettlementImprovementName);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
