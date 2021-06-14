//using System;
//using System.Collections.Generic;
//using System.IO;
//using MTFO.Managers;
//using Newtonsoft.Json;

//namespace Dex.Tweaker.ConfigFile
//{
//    public class Hammer
//    {
//        public static void Load()
//        {
//            JsonPath = Path.Combine(MTFO.Managers.ConfigManager.CustomPath, Name);
//            if (File.Exists(JsonPath))
//            {
//                Param = JsonConvert.DeserializeObject<List<Setting>>(File.ReadAllText(JsonPath));
//            }
//            else
//            {
//                Param = new List<Setting>
//                {
//                    new Setting()
//                    {
//                        itemID = 100U,
//                        damage = new Damage()
//                        {
//                            light = 4f,
//                            heavy = 20f
//                        },
//                        PrecisionDamageMulti = 1f,
//                        cameraDamageRayLength = 1.8f,
//                        inputBufferTime = 0.5f,
//                        maxPushFrequency = 1.2f,
//                        attackDamageSphereDotScale = 0.9f,
//                        pushDamageSphereRadius = 0.6f,
//                        syncTimeout = 2f,
//                        bufferedAttackTime = -1f,
//                        bufferedPushTime = -1f,
//                        staminaSpeed = new StaminaSpeed()
//                        {
//                            min = 0.8f,
//                            max = 1f
//                        },
//                        chargeUp = new ChargeUp()
//                        {
//                            maxDamageTimeDef = 2f,
//                            autoAttackTime = 4f
//                        },
//                        attackMissRight = new AttackData()
//                        {
//                            animeBlendIn = 0.2f,
//                            attackLength = 1f,
//                            attackHitTime = 0.3333333f,
//                            attackCamFwdHitTime = 0.5f,
//                            damageStartTime = 0.3333333f,
//                            damageEndTime = 0.7666667f,
//                            comboEarlyTime = 0.6666667f
//                        },
//                        attackMissLeft = new AttackData()
//                        {
//                            animeBlendIn = 0.2f,
//                            attackLength = 1f,
//                            attackHitTime = 0.3333333f,
//                            attackCamFwdHitTime = 0.5f,
//                            damageStartTime = 0.3333333f,
//                            damageEndTime = 0.7666667f,
//                            comboEarlyTime = 0.6666667f
//                        },
//                        attackHitRight = new AttackData()
//                        {
//                            animeBlendIn = 0.0f,
//                            attackLength = 0.5f,
//                            attackHitTime = 0.5f,
//                            comboEarlyTime = 0.4f
//                        },
//                        attackHitLeft = new AttackData()
//                        {
//                            animeBlendIn = 0.0f,
//                            attackLength = 0.5f,
//                            attackHitTime = 0.5f,
//                            comboEarlyTime = 0.4f
//                        },
//                        attackPush = new AttackData()
//                        {
//                            animeBlendIn = 0.2f,
//                            attackLength = 0.6666667f,
//                            damageStartTime = 0.1333333f,
//                            damageEndTime = 0.2666667f,
//                            attackCamFwdHitTime = 0.3333333f,
//                            comboEarlyTime = 0.8333333f
//                        },
//                        attackChargeUpRight = new AttackData()
//                        {
//                            animeBlendIn = 0.23f
//                        },
//                        attackChargeUpLeft = new AttackData()
//                        {
//                            animeBlendIn = 0.3f
//                        },
//                        attackChargeUpReleaseRight = new AttackData()
//                        {
//                            animeBlendIn = 0.0f,
//                            attackLength = 0.3666667f,
//                            attackHitTime = 0.1333333f,
//                            damageStartTime = 0.0f,
//                            damageEndTime = 0.3666667f,
//                            attackCamFwdHitTime = 0.1333333f,
//                            comboEarlyTime = 0.3f
//                        },
//                        attackChargeUpReleaseLeft = new AttackData()
//                        {
//                            animeBlendIn = 0.0f,
//                            attackLength = 0.3666667f,
//                            attackHitTime = 0.1333333f,
//                            damageStartTime = 0.0f,
//                            damageEndTime = 0.3666667f,
//                            attackCamFwdHitTime = 0.1333333f,
//                            comboEarlyTime = 0.3f
//                        },
//                        head = new Model()
//                        {
//                            scale = new Vector3() { x = 1f, y = 1f, z = 1f },
//                            position = new Vector3() { x = 0, y = 0, z = 0 },
//                            rotation = new Vector3() { x = 0, y = 0, z = 0 }
//                        },
//                        neck = new Model()
//                        {
//                            scale = new Vector3() { x = 1f, y = 1f, z = 1f },
//                            position = new Vector3() { x = 0, y = 0, z = 0 },
//                            rotation = new Vector3() { x = 0, y = 0, z = 0 }
//                        },
//                        handle = new Model()
//                        {
//                            scale = new Vector3() { x = 1f, y = 1.5f, z = 1f },
//                            position = new Vector3() { x = 0, y = 0, z = 0 },
//                            rotation = new Vector3() { x = 0, y = 0, z = 0 }
//                        },
//                        pommel = new Model()
//                        {
//                            scale = new Vector3() { x = 1f, y = 1f, z = 1f },
//                            position = new Vector3() { x = 0, y = 0, z = 0 },
//                            rotation = new Vector3() { x = 0, y = 0, z = 0 }
//                        },
//                        name = "Default",
//                        internalEnabled = false
//                    },
//                    new Setting()
//                    {
//                        itemID = 100U,
//                        damage = new Damage()
//                        {
//                            light = 4f,
//                            heavy = 20f
//                        },
//                        PrecisionDamageMulti = 1f,
//                        cameraDamageRayLength = 100f,
//                        inputBufferTime = 0.5f,
//                        maxPushFrequency = 1.2f,
//                        attackDamageSphereDotScale = 0.9f,
//                        pushDamageSphereRadius = 0.6f,
//                        syncTimeout = 2f,
//                        bufferedAttackTime = -1f,
//                        bufferedPushTime = -1f,
//                        staminaSpeed = new StaminaSpeed()
//                        {
//                            min = 0.8f,
//                            max = 1f
//                        },
//                        chargeUp = new ChargeUp()
//                        {
//                            maxDamageTimeDef = 2f,
//                            autoAttackTime = 4f
//                        },
//                        attackMissRight = new AttackData()
//                        {
//                            animeBlendIn = 0.2f,
//                            attackLength = 1f,
//                            attackHitTime = 0.3333333f,
//                            attackCamFwdHitTime = 0.5f,
//                            damageStartTime = 0.3333333f,
//                            damageEndTime = 0.7666667f,
//                            comboEarlyTime = 0.6666667f
//                        },
//                        attackMissLeft = new AttackData()
//                        {
//                            animeBlendIn = 0.2f,
//                            attackLength = 1f,
//                            attackHitTime = 0.3333333f,
//                            attackCamFwdHitTime = 0.5f,
//                            damageStartTime = 0.3333333f,
//                            damageEndTime = 0.7666667f,
//                            comboEarlyTime = 0.6666667f
//                        },
//                        attackHitRight = new AttackData()
//                        {
//                            animeBlendIn = 0.0f,
//                            attackLength = 0.5f,
//                            attackHitTime = 0.5f,
//                            comboEarlyTime = 0.4f
//                        },
//                        attackHitLeft = new AttackData()
//                        {
//                            animeBlendIn = 0.0f,
//                            attackLength = 0.5f,
//                            attackHitTime = 0.5f,
//                            comboEarlyTime = 0.4f
//                        },
//                        attackPush = new AttackData()
//                        {
//                            animeBlendIn = 0.2f,
//                            attackLength = 0.6666667f,
//                            damageStartTime = 0.1333333f,
//                            damageEndTime = 0.2666667f,
//                            attackCamFwdHitTime = 0.3333333f,
//                            comboEarlyTime = 0.8333333f
//                        },
//                        attackChargeUpRight = new AttackData()
//                        {
//                            animeBlendIn = 0.23f
//                        },
//                        attackChargeUpLeft = new AttackData()
//                        {
//                            animeBlendIn = 0.3f
//                        },
//                        attackChargeUpReleaseRight = new AttackData()
//                        {
//                            animeBlendIn = 0.0f,
//                            attackLength = 0.3666667f,
//                            attackHitTime = 0.1333333f,
//                            damageStartTime = 0.0f,
//                            damageEndTime = 0.3666667f,
//                            attackCamFwdHitTime = 0.1333333f,
//                            comboEarlyTime = 0.3f
//                        },
//                        attackChargeUpReleaseLeft = new AttackData()
//                        {
//                            animeBlendIn = 0.0f,
//                            attackLength = 0.3666667f,
//                            attackHitTime = 0.1333333f,
//                            damageStartTime = 0.0f,
//                            damageEndTime = 0.3666667f,
//                            attackCamFwdHitTime = 0.1333333f,
//                            comboEarlyTime = 0.3f
//                        },
//                        head = new Model()
//                        {
//                            scale = new Vector3() { x = 1.5f, y = 1.5f, z = 1.5f },
//                            position = new Vector3() { x = 0, y = 0, z = 0 },
//                            rotation = new Vector3() { x = 0, y = 0, z = 0 }
//                        },
//                        neck = new Model()
//                        {
//                            scale = new Vector3() { x = 1f, y = 1f, z = 1f },
//                            position = new Vector3() { x = 0, y = 0, z = 0 },
//                            rotation = new Vector3() { x = 0, y = 0, z = 0 }
//                        },
//                        handle = new Model()
//                        {
//                            scale = new Vector3() { x = 1f, y = 1.5f, z = 1f },
//                            position = new Vector3() { x = 0, y = 0, z = 0 },
//                            rotation = new Vector3() { x = 0, y = 0, z = 0 }
//                        },
//                        pommel = new Model()
//                        {
//                            scale = new Vector3() { x = 1f, y = 1f, z = 1f },
//                            position = new Vector3() { x = 0, y = 0, z = 0 },
//                            rotation = new Vector3() { x = 0, y = 0, z = 0 }
//                        },
//                        name = "SniperHammer",
//                        internalEnabled = false
//                    }
//                };
//                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(Param, Formatting.Indented));
//            }
//        }
//        private static string Name { get; } = "Tweaker.Hammer.json";
//        private static string JsonPath { get; set; }
//        public static List<Setting> Param { get; set; }
//        public struct Setting
//        {
//            public uint itemID;
//            public Damage damage;
//            public float PrecisionDamageMulti;
//            public float cameraDamageRayLength;
//            public float inputBufferTime;
//            public float maxPushFrequency;
//            public float attackDamageSphereDotScale;
//            public float pushDamageSphereRadius;
//            public float syncTimeout;
//            public float bufferedAttackTime;
//            public float bufferedPushTime;
//            public StaminaSpeed staminaSpeed;
//            public ChargeUp chargeUp;
//            public AttackData attackMissRight;
//            public AttackData attackMissLeft;
//            public AttackData attackHitRight;
//            public AttackData attackHitLeft;
//            public AttackData attackPush;
//            public AttackData attackChargeUpRight;
//            public AttackData attackChargeUpLeft;
//            public AttackData attackChargeUpReleaseRight;
//            public AttackData attackChargeUpReleaseLeft;
//            public Model head;
//            public Model neck;
//            public Model handle;
//            public Model pommel;
//            public string name;
//            public bool internalEnabled;
//        }

//        public struct Damage
//        {
//            public float light;
//            public float heavy;
//        }
//        public struct StaminaSpeed
//        {
//            public float min;
//            public float max;
//        }
//        public struct ChargeUp
//        {
//            public float maxDamageTimeDef;
//            public float autoAttackTime;
//        }
//        public struct AttackData
//        {
//            public float animeBlendIn;
//            public float attackLength;
//            public float attackHitTime;
//            public float damageStartTime;
//            public float damageEndTime;
//            public float attackCamFwdHitTime;
//            public float comboEarlyTime;
//        }

//        public struct Vector3
//        {
//            public float x;
//            public float y;
//            public float z;
//        }

//        public struct Model
//        {
//            public Vector3 scale;
//            public Vector3 position;
//            public Vector3 rotation;
//        }
//    }
//}
