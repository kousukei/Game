using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        Vector3 randomPosition;
        Vector3 u;
        Vector3 sss;
        Vector3 range;
        bool y;
        //public float a=20;
        float shootingTimeCount;
        Material ma;
        float speed;
    Enemy_1 enemy_1;

        void Start()
        {
            randomPosition = transform.position;
            range = GameObject.Find("GameObject").transform.position;
        enemy_1 = this.gameObject.GetComponent<Enemy_1>();
         }
        /// <summary>
        /// プレイヤーに向かって移動
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="Enemy"></param>
        public void Player_move(GameObject Player,GameObject Enemy)
        {
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        ///
        /// <summary>
        /// ランダム移動
        /// </summary>
        /// <param name="Enemy"></param>
        /// <param name="speed"></param>
        public void random_move(GameObject Enemy, float speed)
        {
        Debug.Log(randomPosition);
            if (randomPosition == Enemy.transform.position)
            {
                u = random();
            }
            else if (enemy_1.hit)
            {
                u = random();
            enemy_1.hit = false;
            }
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, u, speed * Time.deltaTime);
            this.speed = speed;
        }
        /// <summary>
        /// ランダムに移動点の生成
        /// </summary>
        /// <returns></returns>
        Vector3 random()
        { 
            randomPosition = new Vector3(Random.Range(range.x+24, range.x-24), range.y-11, Random.Range(range.z+10, range.z-10));
            return randomPosition;
        }
        /// <summary>
        /// //向き
        /// </summary>
        /// <param name="target"></param>
        /// <param name="Enemy"></param>
       public  void Direction(GameObject Enemy)
        {
            Vector3 vector3 = u - Enemy.transform.position;
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, quaternion, 0.01f);

        }
        /// <summary>
        /// 角度の判定
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="Enemy"></param>
        /// <returns></returns>
        public bool Attack_range(GameObject Player, GameObject Enemy)
        {
            var v0 = Player.transform.position - Enemy.transform.position;
            var v1 = Enemy.transform.forward;
            var dot = Vector3.Dot(v0.normalized, v1.normalized);
            var th = Mathf.Acos(dot) * Mathf.Rad2Deg;
            //45度以上ならば攻撃開始
            if (th < 45)
            {
                //向き(目標)
                Vector3 vector3 = Player.transform.position - Enemy.transform.position;
                Quaternion quaternion = Quaternion.LookRotation(vector3);
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, quaternion, 0.01f);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 距離の判定
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="Enemy"></param>
        /// <param name="withinRange"></param>
        /// <param name="OutOfRange"></param>
        /// <returns></returns>
        public int tracking_range(GameObject Player,GameObject Enemy, float withinRange, float OutOfRange)
        {
            float dist_z = Player.transform.position.z - Enemy.transform.position.z;
            float dist_x = Player.transform.position.x - Enemy.transform.position.x;
            //プレイヤーと敵の距離
            float distance = Mathf.Sqrt(dist_z * dist_z + dist_x * dist_x);
            //一定の距離以下なら1を表示
            if (distance < withinRange)
            {
                return 1;
            }
            //一定の距離なら２を表示
            if (distance< OutOfRange&&distance>withinRange)
            {
                //向き(目標)
                //Direction(Player.transform.position, Enemy);
                Vector3 vector3 = Player.transform.position - Enemy.transform.position;
                Quaternion quaternion = Quaternion.LookRotation(vector3);
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, quaternion, 0.01f);
                return 2;
            }
            //一定の距離以上なら0を表示
            return 0;
            
        }

        public void Attack(Transform transform,GameObject laser,float shootingTime,float laser_speed)
        {
            shootingTimeCount += Time.deltaTime;
            if (shootingTime < shootingTimeCount)
            {
                var gameObject = Instantiate(laser, transform.position, transform.rotation);
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward* laser_speed, ForceMode.Impulse);
                shootingTimeCount = 0;
            }
        }
}


