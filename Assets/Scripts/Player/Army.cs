using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Army : MonoBehaviour
    {
        public GameObject spawnObj;
        public List<GameObject> units;

        public CharacterController controller;
        public float speed = 6f;

        public float offset = 2;

        public void ActiveUnitMoveAnimation(bool active)
        {
            foreach (GameObject unit in units) {
                unit.GetComponent<Animator>().SetBool("isMove", active);
            }
        }

        public bool IsAllUnitDies()
        {
            return units.Count <= 0;
        }

        public void ForceMove()
        {
            if (units.Count <= 0) return;

            float horizontal = Input.GetAxisRaw("Horizontal");
            const float vertical = 1f;

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f) {
                controller.Move(direction * (speed * Time.deltaTime));
            }
        }

        public void FreeMove()
        {
            if (units.Count <= 0) return;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f) {
                controller.Move(direction * (speed * Time.deltaTime));
            }
        }

        public void Spawn(int number)
        {
            for (int i = 0; i < number; i++) {
                GameObject unit = Instantiate(spawnObj, transform.position, Quaternion.identity);

                unit.GetComponent<Unit>().army = this;

                unit.transform.parent = transform;
                units.Add(unit);
            }
            Debug.Log(units.Count);

            SetFormation();
        }

        public void SetFormation()
        {
            List<Vector3> position = new List<Vector3>();

            int count = units.Count;

            float x = 0;
            float z = 0;

            for (int row = 0; row >= -(int) Math.Ceiling(count / 5f); row--) {
                for (int col = -2; col <= 2; col++) {
                    Vector3 pos = new Vector3(x + (col * offset), 0, z + (row * offset));

                    position.Add(pos);
                }
            }


            for (int i = 0; i < count; i++) {
                units[i].GetComponent<Unit>().Move(position[i]);
            }
        }

        public void KillUnit(GameObject unit, bool setFormation = true)
        {
            units.Remove(unit);
            unit.GetComponent<Unit>().Die();
            if (setFormation)
                SetFormation();
        }

        public void KillUnitFromCount(int number)
        {
            if (number >= units.Count) {
                units.Clear();
                return;
            }
            List<GameObject> unitsToKill = units.GetRange(0, number);
            for (int i = 0; i < unitsToKill.Count; i++) {
                KillUnit(unitsToKill[i]);
            }
        }
    }
}