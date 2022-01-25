// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderSetExploration
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderSetExploration : EditorOrder
  {
    public int EmpireIndex = -1;
    public int[] TileIndexes;
    public bool Set;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderSetExploration;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.EmpireIndex);
      int length = this.TileIndexes.Length;
      writer.Write(length);
      for (int index = 0; index < length; ++index)
      {
        int tileIndex = this.TileIndexes[index];
        writer.Write(tileIndex);
      }
      writer.Write(this.Set);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.EmpireIndex = reader.ReadInt32();
      int length = reader.ReadInt32();
      this.TileIndexes = new int[length];
      for (int index = 0; index < length; ++index)
        this.TileIndexes[index] = reader.ReadInt32();
      this.Set = reader.ReadBoolean();
    }

    public override void Serialize(Serializer serializer)
    {
      this.EmpireIndex = serializer.SerializeElement("EmpireIndex", this.EmpireIndex);
      this.TileIndexes = serializer.SerializeElement("TileIndexes", this.TileIndexes);
      this.Set = serializer.SerializeElement("Set", this.Set);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.EmpireIndex);
  }
}
