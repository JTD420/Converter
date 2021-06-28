import 'reflect-metadata';
import { container } from 'tsyringe';
import { Configuration } from './common/config/Configuration';
import { IConverter } from './common/converters/IConverter';
import { EffectConverter } from './converters/effect/EffectConverter';
import { ExternalTextsConverter } from './converters/externaltexts/ExternalTextsConverter';
import { FigureConverter } from './converters/figure/FigureConverter';
import { FurnitureConverter } from './converters/furniture/FurnitureConverter';
import { PetConverter } from './converters/pet/PetConverter';
import { ProductDataConverter } from './converters/productdata/ProductDataConverter';

(async () =>
{
    checkNodeVersion();
    const config = container.resolve(Configuration);
    await config.init();

    const converters = [
        ProductDataConverter,
        ExternalTextsConverter,
        FigureConverter,
        EffectConverter,
        FurnitureConverter,
        PetConverter
    ];

    for(const converterClass of converters)
    {
        const converter = (container.resolve<any>(converterClass) as IConverter);

        await converter.convertAsync();
    }
})();

function checkNodeVersion()
{
    const version = process.version.replace('v', '');
    const major = version.split('.')[0];
    if(parseInt(major) < 14)
    {
        throw new Error('Invalid node version: ' + version + ' please use >= 14');
    }
}