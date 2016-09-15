using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arena : MonoBehaviour {

	public IntVector2 size;
	public FloorCell floorCellPrefab;
	public Wall wallPrefab;
	public Killbox killboxPrefab;

	FloorCell[,] floorCells;
	List<Wall> walls;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Initialize () {
		floorCells = new FloorCell[size.x, size.z];
		walls = new List<Wall>();
	}


	public void Generate () {
		Initialize();

		IntVector2 coordinates;
		coordinates.x = 0;
		coordinates.z = 0;

		while (coordinates.x < size.x) {
			while (coordinates.z < size.z) {
				CreateCell(coordinates);
				CreateWallIfOnEdge(coordinates);
				coordinates.z++;
			}
			coordinates.z = 0;
			coordinates.x++;
		}

		Killbox killboxInstance = Instantiate(killboxPrefab) as Killbox;
		killboxInstance.transform.parent = transform;
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

	bool CreateWallIfOnEdge (IntVector2 coordinates) {
		bool createdWall = false;

		if (coordinates.x == 0 || coordinates.x == size.x - 1) {
			Wall wall = Instantiate(wallPrefab) as Wall;
			wall.transform.parent = transform;
			wall.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
			if (coordinates.x == 0) {
				wall.transform.localRotation = Quaternion.Euler(0, 90, 0);
			}
			else {
				wall.transform.localRotation = Quaternion.Euler(0, 270, 0);
			}
			walls.Add(wall);
		}
		if (coordinates.z == 0 || coordinates.z == size.z - 1) {
			Wall wall = Instantiate(wallPrefab) as Wall;
			wall.transform.parent = transform;
			wall.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f +0.5f);
			if (coordinates.z == size.z - 1)
				wall.transform.localRotation = Quaternion.Euler(0, 180, 0);
			walls.Add(wall);
		}

		return createdWall;
	}
}
