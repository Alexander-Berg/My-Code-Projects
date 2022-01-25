// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderCreateArmyAt
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  [Revision(1, "[FM][22-01-2020] Support create army for animal group.", "D:\\junctions\\sFVM-o2y\\0\\HG\\Development\\Unity Projects\\Amplitude.Mercury.Unityproject\\Assets\\Plugins\\Amplitude.Mercury.Interop\\Orders\\Editors\\EditorOrderCreateArmyAt.cs")]
  public class EditorOrderCreateArmyAt : EditorOrder
  {
    public int EmpireIndex = -1;
    public int AnimalGroupIndex = -1;
    public StaticString UnitDefinitionName;
    public int TileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderCreateArmyAt;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.EmpireIndex);
      writer.Write(this.AnimalGroupIndex);
      writer.Write(this.UnitDefinitionName.ToString());
      writer.Write(this.TileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.EmpireIndex = reader.ReadInt32();
      this.AnimalGroupIndex = reader.ReadInt32();
      this.UnitDefinitionName = new StaticString(reader.ReadString());
      this.TileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      int num = serializer.SerializeRevision(nameof (Serialize), "D:\\junctions\\sFVM-o2y\\0\\HG\\Development\\Unity Projects\\Amplitude.Mercury.Unityproject\\Assets\\Plugins\\Amplitude.Mercury.Interop\\Orders\\Editors\\EditorOrderCreateArmyAt.cs", 44);
      this.EmpireIndex = serializer.SerializeElement("EmpireIndex", this.EmpireIndex);
      if (num >= 1)
        this.AnimalGroupIndex = serializer.SerializeElement("AnimalGroupIndex", this.AnimalGroupIndex);
      this.UnitDefinitionName = serializer.SerializeElement<StaticString>("UnitDefinitionName", this.UnitDefinitionName);
      this.TileIndex = serializer.SerializeElement("TileIndex", this.TileIndex);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.EmpireIndex);
  }
}
