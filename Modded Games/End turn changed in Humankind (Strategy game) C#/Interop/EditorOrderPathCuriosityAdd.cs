// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderPathCuriosityAdd
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderPathCuriosityAdd : EditorOrder
  {
    public int PathCuriosityIndex;
    public int TileIndex;
    public StaticString CuriosityDefinition;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderPathCuriosityAdd;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.PathCuriosityIndex);
      writer.Write(this.CuriosityDefinition.ToString());
      writer.Write(this.TileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.PathCuriosityIndex = reader.ReadInt32();
      this.TileIndex = reader.ReadInt32();
      this.CuriosityDefinition = new StaticString(reader.ReadString());
    }

    public override void Serialize(Serializer serializer)
    {
      this.PathCuriosityIndex = serializer.SerializeElement("PathCuriosityIndex", this.PathCuriosityIndex);
      this.TileIndex = serializer.SerializeElement("TileIndex", this.TileIndex);
      this.CuriosityDefinition = serializer.SerializeElement<StaticString>("CuriosityDefinition", this.CuriosityDefinition);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
