using UnityEngine;
using System.Collections;

public class Arena : MonoBehaviour {

	public FloorCell floorCellPrefab;
	public IntVector2 size;

	FloorCell[,] floorCells;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Generate () {
		floorCells = new FloorCell[size.x, size.z];
		IntVector2 coordinates;
		coordinates.x = 0;
		coordinates.z = 0;

		while (coordinates.x < size.x) {
			while (coordinates.z < size.z) {
				CreateCell(coordinates);
				coordinates.z++;
			}
			coordinates.z = 0;
			coordinates.x++;
		}
	}


	FloorCell CreateCell (IntVector2 coordinates) {
		FloorCell newCell = Instantiate(floorCellPrefab) as FloorCell;
		newCell.name = "Arena Floor Cell " + coordinates.x + ", " + coordinates.z;

		floorCells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;

		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);

		return newCell;
	}
}
