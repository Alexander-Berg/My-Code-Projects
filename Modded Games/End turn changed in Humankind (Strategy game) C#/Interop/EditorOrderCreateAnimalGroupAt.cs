// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderCreateAnimalGroupAt
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderCreateAnimalGroupAt : EditorOrder
  {
    public int RequestedAnimalGroupIndex;
    public StaticString AnimalUnitDefinitionName;
    public int TileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderCreateAnimalGroupAt;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.RequestedAnimalGroupIndex);
      writer.Write(this.AnimalUnitDefinitionName.ToString());
      writer.Write(this.TileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.RequestedAnimalGroupIndex = reader.ReadInt32();
      this.AnimalUnitDefinitionName = new StaticString(reader.ReadString());
      this.TileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.RequestedAnimalGroupIndex = serializer.SerializeElement("RequestedAnimalGroupIndex", this.RequestedAnimalGroupIndex);
      this.AnimalUnitDefinitionName = serializer.SerializeElement<StaticString>("AnimalUnitDefinitionName", this.AnimalUnitDefinitionName);
      this.TileIndex = serializer.SerializeElement("TileIndex", this.TileIndex);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
