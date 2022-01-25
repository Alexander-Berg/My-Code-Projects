// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderSetArmyMission
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Mercury.Simulation;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderSetArmyMission : EditorOrder
  {
    public int ArmyTileIndex;
    public ArmyMissionTypes ArmyMissionType;
    public int TargetTileIndex = -1;
    public int TargetIndex = -1;
    public ulong TargetGuid;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderSetArmyMission;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.ArmyTileIndex);
      writer.Write((int) this.ArmyMissionType);
      writer.Write(this.TargetTileIndex);
      writer.Write(this.TargetIndex);
      writer.Write(this.TargetGuid);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.ArmyTileIndex = reader.ReadInt32();
      this.ArmyMissionType = (ArmyMissionTypes) reader.ReadInt32();
      this.TargetTileIndex = reader.ReadInt32();
      this.TargetIndex = reader.ReadInt32();
      this.TargetGuid = reader.ReadUInt64();
    }

    public override void Serialize(Serializer serializer)
    {
      this.ArmyTileIndex = serializer.SerializeElement("ArmyTileIndex", this.ArmyTileIndex);
      this.ArmyMissionType = (ArmyMissionTypes) serializer.SerializeElement("ArmyMissionType", (int) this.ArmyMissionType);
      this.TargetTileIndex = serializer.SerializeElement("TargetTileIndex", this.TargetTileIndex);
      this.TargetIndex = serializer.SerializeElement("TargetIndex", this.TargetIndex);
      this.TargetGuid = serializer.SerializeElement("TargetGuid", this.TargetGuid);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => true;
  }
}
