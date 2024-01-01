import { defineConfig } from 'vite';
import appsettings from './appsettings.json';

export default defineConfig({
    name: 'spark',
    plugins: [],
    build: {
        //manifest: appsettings.Vite.Manifest,
        manifest: false,
        outDir: './wwwroot/build',
        rollupOptions: {
            input: [
                'Assets/Js/app.js',
                'Assets/Css/app.css'
            ],
            output: {
                entryFileNames: `assets/[name].js`,
                chunkFileNames: `assets/[name].js`,
                assetFileNames: `assets/[name].[ext]`
            }
        },
    },
    server: {
        port: appsettings.Vite.Server.Port,
        strictPort: true,
        hmr: {
            host: "localhost",
            clientPort: appsettings.Vite.Server.Port,
        }
    }
});