// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderEnqueueConstructible
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Mercury.Simulation;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderEnqueueConstructible : EditorOrder
  {
    public int SettlementTileIndex;
    public StaticString ConstructibleName;
    public int ConstructionTileIndex = -1;
    public EnqueuePosition EnqueuePosition = EnqueuePosition.AtEnd;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderEnqueueConstructible;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.SettlementTileIndex);
      writer.Write(this.ConstructibleName.ToString());
      writer.Write(this.ConstructionTileIndex);
      writer.Write((int) this.EnqueuePosition);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.SettlementTileIndex = reader.ReadInt32();
      this.ConstructibleName = new StaticString(reader.ReadString());
      this.ConstructionTileIndex = reader.ReadInt32();
      this.EnqueuePosition = (EnqueuePosition) reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.SettlementTileIndex = serializer.SerializeElement("SettlementTileIndex", this.SettlementTileIndex);
      this.ConstructibleName = serializer.SerializeElement<StaticString>("ConstructibleName", this.ConstructibleName);
      this.ConstructionTileIndex = serializer.SerializeElement("ConstructionTileIndex", this.ConstructionTileIndex);
      this.EnqueuePosition = (EnqueuePosition) serializer.SerializeElement("EnqueuePosition", (int) this.EnqueuePosition);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
