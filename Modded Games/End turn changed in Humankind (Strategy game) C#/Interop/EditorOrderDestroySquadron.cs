// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderDestroySquadron
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderDestroySquadron : EditorOrder
  {
    public int SquadronTileIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderDestroySquadron;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.SquadronTileIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.SquadronTileIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer) => this.SquadronTileIndex = serializer.SerializeElement("SquadronTileIndex", this.SquadronTileIndex);

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
