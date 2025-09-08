using UnityEngine;

public interface ITriggerCheckable 
{
    bool IsAggroed { get; set; }
    bool IsWithinStrikingDistance{ get; set; }
    void SetAggroStatus(bool IsAgroed);
    void SetStrikingDistanceBool(bool isWithinStrikingDistance);
}
