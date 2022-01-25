// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderMergeSettlementIntoCity
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderMergeSettlementIntoCity : EditorOrder
  {
    public int CityTileIndex;
    public int SettlementToMergeTileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderMergeSettlementIntoCity;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.CityTileIndex);
      writer.Write(this.SettlementToMergeTileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.CityTileIndex = reader.ReadInt32();
      this.SettlementToMergeTileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.CityTileIndex = serializer.SerializeElement("CityTileIndex", this.CityTileIndex);
      this.SettlementToMergeTileIndex = serializer.SerializeElement("SettlementToMergeTileIndex", this.SettlementToMergeTileIndex);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
