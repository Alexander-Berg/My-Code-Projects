// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderAddUnitToArmy
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderAddUnitToArmy : EditorOrder
  {
    public StaticString UnitDefinitionName;
    public int ArmyTileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderAddUnitToArmy;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.UnitDefinitionName.ToString());
      writer.Write(this.ArmyTileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.UnitDefinitionName = new StaticString(reader.ReadString());
      this.ArmyTileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.UnitDefinitionName = serializer.SerializeElement<StaticString>("UnitDefinitionName", this.UnitDefinitionName);
      this.ArmyTileIndex = serializer.SerializeElement("ArmyTileIndex", this.ArmyTileIndex);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
