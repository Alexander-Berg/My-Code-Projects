// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderCreateCuriosityAt
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderCreateCuriosityAt : EditorOrder
  {
    public StaticString CuriosityDefinitionName;
    public int TileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderCreateCuriosityAt;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.CuriosityDefinitionName.ToString());
      writer.Write(this.TileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.CuriosityDefinitionName = new StaticString(reader.ReadString());
      this.TileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.CuriosityDefinitionName = serializer.SerializeElement<StaticString>("CuriosityDefinitionName", this.CuriosityDefinitionName);
      this.TileIndex = serializer.SerializeElement("TileIndex", this.TileIndex);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
