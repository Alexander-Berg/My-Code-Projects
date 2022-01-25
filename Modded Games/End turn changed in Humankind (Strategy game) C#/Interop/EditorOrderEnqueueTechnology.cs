// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderEnqueueTechnology
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Mercury.Simulation;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderEnqueueTechnology : EditorOrder
  {
    public int EmpireIndex = -1;
    public StaticString TechnologyName;
    public EnqueuePosition EnqueuePosition = EnqueuePosition.AtEnd;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderEnqueueTechnology;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.EmpireIndex);
      writer.Write(this.TechnologyName.ToString());
      writer.Write((int) this.EnqueuePosition);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.EmpireIndex = reader.ReadInt32();
      this.TechnologyName = new StaticString(reader.ReadString());
      this.EnqueuePosition = (EnqueuePosition) reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.EmpireIndex = serializer.SerializeElement("EmpireIndex", this.EmpireIndex);
      this.TechnologyName = serializer.SerializeElement<StaticString>("TechnologyName", this.TechnologyName);
      this.EnqueuePosition = (EnqueuePosition) serializer.SerializeElement("EnqueuePosition", (int) this.EnqueuePosition);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.EmpireIndex);
  }
}
