import request from "@/store/request";

const project = {
    namespaced: true,
    actions: {
        async GET(context, query){
            const data = await request(context, "/project/"+query, "GET")
            return data
        },
        async POST(context, body){
            const data = await request(context, "/project/", "POST", body)
            return data
        },
        async PATCH(context, query){
            const data = await request(context, "/project/"+query, "PATCH")
            return data
        },
        async DELETE(context, id){
            const data = await request(context, "/project/"+id, "DELETE")
            return data
        },
        // async PUT(context, body){
        //     const data = await request(context, "/project/"+body.id, "PUT", body.form)
        //     return data
        // },
    }
}

export default project