import request from "@/store/request";

const file = {
    namespaced: true,
    actions: {
        async GET(context, query){
            const data = await request(context, "/file/"+query, "GET")
            return data
        },
        async DELETE(context, id){
            const data = await request(context, "/file/"+id, "DELETE")
            return data
        },
        async PUT(context, body){
            const data = await request(context, "/file/"+body.id, "PUT", body.form)
            return data
        },
    }
}

export default file