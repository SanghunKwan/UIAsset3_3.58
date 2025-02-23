using UnityEngine;
using System;
using SGA.UI;

namespace SGA.Temp
{
    public class SoundManager : MonoBehaviour
    {
        AudioSource bgmSource;

        [SerializeField] SliderNToggle mainSliderNToggleDatas;
        [SerializeField] SliderNToggle bgmSliderNToggleData;

        [SerializeField] float[] audioSourceMax;

        Action[] toggleChangeAction;
        Action[] sliderChangeAction;


        private void Awake()
        {
            bgmSource = transform.GetChild(0).GetComponent<AudioSource>();

            bgmSliderNToggleData.toggleChangeAction += ToggleChangeAction;
            bgmSliderNToggleData.sliderChangeAction += SliderChangeAction;

            mainSliderNToggleDatas.toggleChangeAction += MainToggleChangeAction;
            mainSliderNToggleDatas.sliderChangeAction += MainSliderChangeAction;

            SetAction();
        }
        void SetAction()
        {
            toggleChangeAction = new Action[6];
            toggleChangeAction[0] = () =>
            {
                bgmSource.mute =
                mainSliderNToggleDatas.toggleValue[0] | bgmSliderNToggleData.toggleValue[0];
            };
            toggleChangeAction[1] = () =>
            {
                bgmSource.bypassEffects =
                mainSliderNToggleDatas.toggleValue[1] | bgmSliderNToggleData.toggleValue[1];
            };
            toggleChangeAction[2] = () =>
            {
                bgmSource.bypassListenerEffects =
                mainSliderNToggleDatas.toggleValue[2] | bgmSliderNToggleData.toggleValue[2];
            };
            toggleChangeAction[3] = () =>
            {
                bgmSource.bypassReverbZones =
                mainSliderNToggleDatas.toggleValue[3] | bgmSliderNToggleData.toggleValue[3];
            };
            toggleChangeAction[4] = () =>
            {
                bgmSource.playOnAwake =
                mainSliderNToggleDatas.toggleValue[4] | bgmSliderNToggleData.toggleValue[4];
            };
            toggleChangeAction[5] = () =>
            {
                bgmSource.loop =
                mainSliderNToggleDatas.toggleValue[5] | bgmSliderNToggleData.toggleValue[5];
            };


            sliderChangeAction = new Action[6];
            sliderChangeAction[0] = () => { bgmSource.priority = Mathf.RoundToInt(MultiplyWithMain(0, bgmSliderNToggleData)); };
            sliderChangeAction[1] = () => { bgmSource.volume = MultiplyWithMain(1, bgmSliderNToggleData); };
            sliderChangeAction[2] = () => { bgmSource.pitch = MultiplyWithMain(2, bgmSliderNToggleData); };
            sliderChangeAction[3] = () => { bgmSource.panStereo = MultiplyWithMain(3, bgmSliderNToggleData); };
            sliderChangeAction[4] = () => { bgmSource.spatialBlend = MultiplyWithMain(4, bgmSliderNToggleData); };
            sliderChangeAction[5] = () => { bgmSource.reverbZoneMix = MultiplyWithMain(5, bgmSliderNToggleData); };
        }
        float MultiplyWithMain(int index, in SliderNToggle sliderNToggleData)
        {
            return mainSliderNToggleDatas.sliderValue[index] * sliderNToggleData.sliderValue[index] / audioSourceMax[index];
        }
        public void ToggleChangeAction(int index)
        {
            toggleChangeAction[index]();
        }
        public void SliderChangeAction(int index)
        {
            sliderChangeAction[index]();
        }
        public void MainToggleChangeAction(int index)
        {
            ToggleChangeAction(index);
        }
        public void MainSliderChangeAction(int index)
        {
            SliderChangeAction(index);
        }
    }
}
