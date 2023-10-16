﻿/*
 * Para usar este código debes instalar "imagesharp"
 * https://docs.sixlabors.com/articles/imagesharp/index.html
 * Instalar esta librería es realmente fácil. Yo usé NuGet que aparece en la barra
 * de abajo en Rider. Luego busqué la librería "SixLabors.ImageSharp" y puse instalar.
 */

using MyPhotoshop;
using MyPhotoshop.Effects;

IPhotoEffect[] availableEffects = new IPhotoEffect[] {  new BlackAndWhiteEffect(), 
                                                        new DarkenEffect(), 
                                                        new BrightenEffect(), 
                                                        new RotateEffect(), 
                                                        new MirrorEffect(),
                                                        new BlurEffect(),
                                                        new EdgeDetectionEffect() };
string folder = "imgs";
Controller.Run(folder, availableEffects);