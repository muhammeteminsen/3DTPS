using UnityEngine;



namespace TPS
{
    public class Animations
    {

        public void Forward(Animator MainAnimation, string MainAnimationForwardName, float[] MainAnimationForwardValue, bool BackMove,
            bool RightMove, bool LeftMove, bool LeftShift)
        {
            //Forward
            if (Input.GetKey(KeyCode.W) && !BackMove && !RightMove && !LeftMove)
            {
                MainAnimation.SetFloat(MainAnimationForwardName, MainAnimationForwardValue[0]);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    MainAnimation.SetFloat(MainAnimationForwardName, MainAnimationForwardValue[1]);
                    if (Input.GetKey(KeyCode.D))
                    {
                        MainAnimation.SetFloat(MainAnimationForwardName, MainAnimationForwardValue[2]);

                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        MainAnimation.SetFloat(MainAnimationForwardName, MainAnimationForwardValue[3]);

                    }
                }
                if (Input.GetKey(KeyCode.D) && !LeftShift)
                {
                    MainAnimation.SetFloat(MainAnimationForwardName, MainAnimationForwardValue[4]);

                }
                if (Input.GetKey(KeyCode.A) && !LeftShift)
                {
                    MainAnimation.SetFloat(MainAnimationForwardName, MainAnimationForwardValue[5]);

                }

                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    MainAnimation.SetFloat(MainAnimationForwardName, MainAnimationForwardValue[6]);

                }



            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                MainAnimation.SetFloat(MainAnimationForwardName, 0f);
            }
        }

        public void Backwards(Animator MainAnimation, string MainAnimationBackwardsName, float[] MainAnimationBackwardsValue, bool ForwardMove,
            bool RightMove, bool LeftMove, bool LeftShift)
        {
            if (Input.GetKey(KeyCode.S) && !ForwardMove && !RightMove && !LeftMove)
            {
                MainAnimation.SetFloat(MainAnimationBackwardsName, MainAnimationBackwardsValue[0]);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    MainAnimation.SetFloat(MainAnimationBackwardsName, MainAnimationBackwardsValue[1]);
                    if (Input.GetKey(KeyCode.D))
                    {
                        MainAnimation.SetFloat(MainAnimationBackwardsName, MainAnimationBackwardsValue[2]);

                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        MainAnimation.SetFloat(MainAnimationBackwardsName, MainAnimationBackwardsValue[3]);

                    }
                }
                else if (Input.GetKey(KeyCode.D) && !LeftShift)
                {
                    MainAnimation.SetFloat(MainAnimationBackwardsName, MainAnimationBackwardsValue[4]);

                }
                else if (Input.GetKey(KeyCode.A) && !LeftShift)
                {
                    MainAnimation.SetFloat(MainAnimationBackwardsName, MainAnimationBackwardsValue[5]);

                }

                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    MainAnimation.SetFloat(MainAnimationBackwardsName, MainAnimationBackwardsValue[6]);

                }

            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                MainAnimation.SetFloat(MainAnimationBackwardsName, 0f);
            }

        }

        public void Right(Animator MainAnimation, string MainAnimationRightName, float[] MainAnimationRightValue, bool LeftMove, bool BackMove)
        {
            if (Input.GetKey(KeyCode.D) && !LeftMove && !BackMove)
            {

                MainAnimation.SetFloat(MainAnimationRightName, MainAnimationRightValue[0]);
                if (Input.GetKey(KeyCode.W))
                {
                    MainAnimation.SetFloat(MainAnimationRightName, MainAnimationRightValue[0]);
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        MainAnimation.SetFloat(MainAnimationRightName, MainAnimationRightValue[0]);
                    }
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        MainAnimation.SetFloat(MainAnimationRightName, MainAnimationRightValue[0]);
                    }
                }
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    MainAnimation.SetFloat(MainAnimationRightName, MainAnimationRightValue[0]);
                }

                else if (Input.GetKey(KeyCode.LeftShift))
                {
                    MainAnimation.SetFloat(MainAnimationRightName, MainAnimationRightValue[0]);
                }

            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                MainAnimation.SetFloat(MainAnimationRightName, 0f);
            }

        }

        public void Left(Animator MainAnimation, string MainAnimationLeftName, float[] MainAnimationLeftValue, bool RightMove, bool BackMove)
        {
            if (Input.GetKey(KeyCode.A) && !RightMove && !BackMove)
            {

                MainAnimation.SetFloat(MainAnimationLeftName, MainAnimationLeftValue[0]);
                if (Input.GetKey(KeyCode.W))
                {
                    MainAnimation.SetFloat(MainAnimationLeftName, MainAnimationLeftValue[1]);

                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        MainAnimation.SetFloat(MainAnimationLeftName, MainAnimationLeftValue[2]);
                    }
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        MainAnimation.SetFloat(MainAnimationLeftName, MainAnimationLeftValue[3]);
                    }
                }
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    MainAnimation.SetFloat(MainAnimationLeftName, MainAnimationLeftValue[4]);
                }

                else if (Input.GetKey(KeyCode.LeftShift))
                {
                    MainAnimation.SetFloat(MainAnimationLeftName, MainAnimationLeftValue[5]);
                }

            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                MainAnimation.SetFloat(MainAnimationLeftName, 0f);
            }

        }

    }
    public class Movement
    {

    }

}

