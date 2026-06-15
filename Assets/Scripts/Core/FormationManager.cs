using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    public enum FormationType
    {
        Line,
        Box,
        Wedge
    }

    /// <summary>
    /// Менеджер построений групп юнитов.
    /// </summary>
    public static class FormationManager
    {
        public static List<Vector3> GetFormationPositions(Vector3 center, int count, FormationType type, float spacing = 3f)
        {
            List<Vector3> positions = new List<Vector3>();

            switch (type)
            {
                case FormationType.Box:
                    int side = Mathf.CeilToInt(Mathf.Sqrt(count));
                    for (int i = 0; i < count; i++)
                    {
                        float x = (i % side - (side - 1) / 2f) * spacing;
                        float z = (i / side - (side - 1) / 2f) * spacing;
                        positions.Add(center + new Vector3(x, 0, z));
                    }
                    break;
                case FormationType.Line:
                    for (int i = 0; i < count; i++)
                    {
                        float x = (i - (count - 1) / 2f) * spacing;
                        positions.Add(center + new Vector3(x, 0, 0));
                    }
                    break;
            }

            return positions;
        }
    }
}
