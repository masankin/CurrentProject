//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Skill.proto
namespace PB
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"HSSkill")]
  public partial class HSSkill : global::ProtoBuf.IExtensible
  {
    public HSSkill() {}
    
    private int _skillId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"skillId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int skillId
    {
      get { return _skillId; }
      set { _skillId = value; }
    }
    private int _level;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int level
    {
      get { return _level; }
      set { _level = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}