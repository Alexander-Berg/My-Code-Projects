// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderForcePeace
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderForcePeace : EditorOrder
  {
    public int LeftEmpireIndex = -1;
    public int RightEmpireIndex = -1;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderForcePeace;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.LeftEmpireIndex);
      writer.Write(this.RightEmpireIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.LeftEmpireIndex = reader.ReadInt32();
      this.RightEmpireIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.LeftEmpireIndex = serializer.SerializeElement("LeftEmpireIndex", this.LeftEmpireIndex);
      this.RightEmpireIndex = serializer.SerializeElement("RightEmpireIndex", this.RightEmpireIndex);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.LeftEmpireIndex) && resolver.TryResolveEmpireIndex(ref this.RightEmpireIndex);
  }
}
