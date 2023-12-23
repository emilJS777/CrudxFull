import Vuex from "vuex";
import technology from "@/store/modules/technology";
import project from "@/store/modules/project";
import crudStatic from "@/store/modules/crudStatic";
import crud from "@/store/modules/crud";
import file from "@/store/modules/file";

export default new Vuex.Store({
    namespaced: true,
    modules: {
        technology,
        project,
        crudStatic,
        crud,
        file,
    }
})